using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {
    public GameObject player;

    void OnTriggerEnter(Collider colliderInfo)
    { 
        player.GetComponent<Health>().Respawn();
    }
}
