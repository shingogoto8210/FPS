using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weapons;
    public AudioClip changeSound;
    public int currentNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if(i == currentNum)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            AudioSource.PlayClipAtPoint(changeSound, Camera.main.transform.position);
            currentNum = (currentNum + 1) % weapons.Length;
            for(int i = 0; i < weapons.Length; i++)
            {
                if(i == currentNum)
                {
                    weapons[i].SetActive(true);
                }
                else
                {
                    weapons[i].SetActive(false);
                }
            }
        }
    }
}
