using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPSlider : MonoBehaviour
{
    private Slider slider;
    private int eHP;
    private GameObject enemyCanvas;
    // Start is called before the first frame update
    void Start()
    {
        eHP = transform.root.gameObject.GetComponent<EnemyHealth>().enemyHP;

        slider = GetComponent<Slider>();
        slider.value = eHP;
        slider.maxValue = eHP;
        enemyCanvas = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        eHP = transform.root.gameObject.GetComponent<EnemyHealth>().enemyHP;
        slider.value = eHP;
        enemyCanvas.transform.LookAt(GameObject.Find("FPSCamera").transform);
    }
}
