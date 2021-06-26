using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    public Image damageScreenImage;
    private Color color;
    public int playerHP;
    // Start is called before the first frame update
    void Start()
    {
        damageScreenImage = GameObject.Find("DamageScreen").GetComponent<Image>();
        color = damageScreenImage.color;
        color.a = 0.0f;
        damageScreenImage.color = color;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyShell")
        {
            playerHP -= 1;
            Destroy(other.gameObject);
            color.a += 0.1f;
            damageScreenImage.color = color;
        }

    }

}
