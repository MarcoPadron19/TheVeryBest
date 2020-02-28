using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {
    public GameObject player;


    void OnTriggerEnter(Collider colliderInfo)
    {
        //This just let's you know (in the console) that there was a collision.
        // You can't start debugging code in this OnTriggerEnter method (or function) until you know it's at least being called
        //Debug.Log("Detected collision between " + gameObject.name + " and " + colliderInfo.name);
        //if (colliderInfo.gameObject == player)
        //{
        //    Debug.Log("Player fell to their death.");
       // }

       // GameManager.gameManagerInstance.IncreaseScore(-pointsLostForDying);

        // This calls the Respawn function from the Health script component on the player (an instance which we set above in the start function to equal to the thing tagged "Player", which is the ball
        player.GetComponent<Health>().Respawn();
        Debug.Log("Player Position" + transform.position);
    }
}
