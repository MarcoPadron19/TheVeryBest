using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            Debug.Log("Hit");
        }
    }
}
