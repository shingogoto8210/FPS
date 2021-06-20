using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    public float shotSpeed;
    public int shotCount = 30;
    private float shotInterval;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            shotInterval += 1;

            if(shotInterval % 5 == 0 && shotCount > 0)
            {
                shotCount -= 1;

                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x+90, transform.parent.eulerAngles.y, 0)) ;
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward * shotSpeed);
                Destroy(bullet, 3.0f);
                AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
            }
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            shotCount = 30;
            AudioSource.PlayClipAtPoint(reloadSound, Camera.main.transform.position);
        }
    }
}
