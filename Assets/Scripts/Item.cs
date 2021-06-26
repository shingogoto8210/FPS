using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private DamageScreen damageScreen;
    public int reward;

    // Start is called before the first frame update
    void Start()
    {
        damageScreen = player.GetComponent<DamageScreen>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            damageScreen.AddHP(reward);
            Destroy(gameObject);
        }
    }
}
