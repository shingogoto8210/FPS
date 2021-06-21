using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDamage : MonoBehaviour
{
    private float radius = 20.0f;
    private float power = 100.0f;

    void OnParticleCollision(GameObject other)
    {
        Vector3 explosionPos = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, 15.0f);
            }
            if(hit.gameObject.tag == "Enemy")
            {
                Destroy(hit.gameObject, 1.5f);
            }
        }
    }
}
