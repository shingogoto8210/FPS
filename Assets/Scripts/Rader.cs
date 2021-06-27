using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rader : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.parent.LookAt(target);
        }
    }
}
