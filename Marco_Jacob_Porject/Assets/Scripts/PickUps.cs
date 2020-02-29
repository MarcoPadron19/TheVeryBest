using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script manages the coins (pick ups) in the game. It rotates them, and also checks
 * to see if the player hits them. Remember the rules for instances. Each instance of a coin in 
 * the game gets its own copy of this script. */

public class PickUps : MonoBehaviour
{
    public float coinRotationSpeed = 90f;
    public GameObject player;
    public int maxCarry;

    private static int score;

    public AudioClip pickUpCollected;

    // Update is called once per frame
    void Update()
    {
        // This rotates the coin around a vertical axis (.up). Time.deltaTime is super important.
        // It compensates for the fact that framerate varies, so it'll only rotate the coin enough
        // to make up for how much time has passed since the last Update function call
        transform.Rotate(Vector3.up, coinRotationSpeed * Time.deltaTime);

        score = GameManager.score;  //  Update our score continuously.
    }

    // This is a collision detection script. You use "OnTriggerEnter" when you have checked the box
    // to make your Collider a Trigger (it must also be convex too)
    // Making something a trigger means that it will register the collision, but things won't bounce off of it
    // You want to pick up coins, not hit them. Also, the killbox below is a Trigger collider without an actual mesh
    void OnTriggerEnter(Collider colliderInfo)
    {
        // This just let's you know (in the console) that there was a collision.
        // You can't start debugging code in this OnTriggerEnter method (or function) until you know it's at least being called
        Debug.Log("Detected collision between " + gameObject.name + " and " + colliderInfo.name);

        // *** Increase player score
        //GameManager.gameManagerInstance.Collect(1);

        // *** Destroy the coin ***
        // Note: Destroy(this); destroys this, the script attached to the coin (not what you want)
        // Destroy(this.gameObject); destroys whatever game object this (the script) is attached to
        //AudioSource.PlayClipAtPoint(pickUpCollected, player.transform.position);
        if (score < maxCarry)
        {
            Destroy(this.gameObject);

            GameManager.gameManagerInstance.IncreaseScore(1);
        }
        else
        {
            GameManager.gameManagerInstance.IncreaseScore(0);
        }
    }
}