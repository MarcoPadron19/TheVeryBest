using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{

	private Vector3 respawnPosition;
	private Quaternion respawnRotation;
	

	// Use this for initialization
	void Start () 
	{
       Debug.Log("Starting Position and Rotation " + respawnPosition + " and " + respawnRotation);
        // store initial position as respawn location
        respawnPosition = transform.position;
		respawnRotation = transform.rotation;
        //Debug.Log("Starting Position and Rotation " + respawnPosition + " and " + respawnRotation);


    }

    // Update is called once per frame
    void Update()
    {


    }


    public void Respawn()
    {
        Debug.Log("Respawn Position and Rotation " + respawnPosition + " and " + respawnRotation);
        transform.rotation = respawnRotation;
        transform.position = respawnPosition;
    }
         
}
