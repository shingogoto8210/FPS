using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public GameObject enemyShellPrefab;
    private int interval;
    public int shotPower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        interval += 1;
        if(interval % 60 == 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = enemyShell.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * shotPower);
            Destroy(enemyShell, 2.0f);
        }
    }
}
