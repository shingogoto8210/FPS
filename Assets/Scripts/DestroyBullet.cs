using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public GameObject effectPrefab;


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Debug.Log(other.contacts.Length);

            foreach(ContactPoint contactPoint in other.contacts)
            {
                GameObject effect = Instantiate(effectPrefab, contactPoint.point,Quaternion.identity);
                Destroy(effect, 2.0f);
            }
        }
    }
}
