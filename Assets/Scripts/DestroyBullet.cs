﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public GameObject effectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);

            foreach(ContactPoint contactPoint in other.contacts)
            {
                GameObject effect = Instantiate(effectPrefab, transform.position,Quaternion.identity);
                Destroy(effect, 2.0f);
            }
        }
    }
}
