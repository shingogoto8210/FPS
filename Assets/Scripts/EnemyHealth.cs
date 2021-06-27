using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHP;
    public AudioClip audioClip;

    private void Start()
    {

    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            enemyHP -= 1;
            AudioSource.PlayClipAtPoint(audioClip,other.transform.position);
            if(enemyHP < 0)
            {
                enemyHP = 0;
            }
        }
    }
}
