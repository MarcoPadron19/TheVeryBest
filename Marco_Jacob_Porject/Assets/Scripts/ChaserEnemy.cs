using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour 
{
    public float chaseSpeed = 1.0f;
    public float minDist = 1f; 
    public Transform target; // The location of the player

    // Use this for initialization
    void Start () 
    {
        // if no target specified, assume the player
        if (target == null)
        { 
        }
        if (GameObject.FindWithTag("Player") != null)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
    }
	
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // face the target's x&z position, but don't look up or down (y position set to self)
        transform.LookAt(new Vector3(target.position.x, this.gameObject.transform.position.y, target.position.z));


        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);

        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
            transform.position += transform.forward * chaseSpeed * Time.deltaTime;
    }

    // Set the target of the chaser
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }


}