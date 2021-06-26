using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image damageScreenImage;
    private Color color;
    public int playerHP;
    private int playerMaxHP = 10;
    private CameraShake shake;
    // Start is called before the first frame update
    void Start()
    {
        damageScreenImage = GameObject.Find("DamageScreen").GetComponent<Image>();
        color = damageScreenImage.color;
        color.a = 0.0f;
        damageScreenImage.color = color;
        shake = GameObject.Find("FPSCamera").GetComponent<CameraShake>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyShell")
        {
            playerHP -= 1;
            Destroy(other.gameObject);
            color.a += 0.1f;
            damageScreenImage.color = color;
            shake.Shake(0.2f, 0.1f);
        }

    }

    public void AddHP(int amount)
    {
        playerHP += amount;
        color.a -= 0.1f * amount;
        if (playerHP > playerMaxHP)
        {
            playerHP = playerMaxHP;
        }
        if(color.a < 0)
        {
            color.a = 0; 
        }
        damageScreenImage.color = color;
    }

}
