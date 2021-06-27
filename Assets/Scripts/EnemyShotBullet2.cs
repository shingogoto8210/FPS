using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotBullet2 : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public GameObject effectPrefab;
    public AudioClip shotSound;
    public float shotSpeed;
    private float timeCount;
    private float timeBetweenShot = 0.5f;
    private bool isShot = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyShotA());
    }


    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
    }

    private IEnumerator EnemyShotA()
    {
        while(isShot == true)
        {
            GameObject enemyBullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
            Rigidbody enemyBulletRb = enemyBullet.GetComponent<Rigidbody>();
            enemyBulletRb.AddForce(transform.forward * shotSpeed);
            Destroy(enemyBullet, 4.0f);
            AudioSource.PlayClipAtPoint(shotSound, Camera.main.transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            yield return new WaitForSeconds(0.1f);

            if(timeCount > timeBetweenShot)
            {
                isShot = false;
                Invoke("ShotReturn", 1.5f);
            }
        }
    }

    void ShotReturn()
    {
        isShot = true;
        timeCount = 0f;
        StartCoroutine(EnemyShotA());
    }
}
