using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	
	private Vector3 respawnPosition;
	private Quaternion respawnRotation;
	

	// Use this for initialization
	void Start () 
	{
		// store initial position as respawn location
		respawnPosition = transform.position;
		respawnRotation = transform.rotation;

		
	}

    // Update is called once per frame
    void Update()
    {


    }


    public void Respawn()
    {
        gameObject.transform.position = respawnPosition;
        gameObject.transform.rotation = respawnRotation;
    }
         
}
