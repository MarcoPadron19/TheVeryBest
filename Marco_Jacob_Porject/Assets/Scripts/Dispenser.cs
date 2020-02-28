using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
     // player main camera tag as Player
     private Transform _target;
    // mutiple prefab objects
    public GameObject prefab;
    //Maximum number of prefabs
    public int numMax;
    // Minimum and Maximum placement of prefabs
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;
    private int i = 0;

   
    void Update()
    {

       // used to find the Player
        GameObject _target = GameObject.FindGameObjectWithTag("Player");
        // get the distance between the player and the Prefab GameObject
        float dist = Vector3.Distance(_target.transform.position, this.transform.position);

        if (dist > 30f)
        {
            // int for the while loop
            i = GameObject.FindGameObjectsWithTag("PickUp1").Length;
        }

        if (dist < 20f)
        {
            while (i <= numMax)
            {
                Object.Instantiate(prefab, new Vector3(transform.position.x + Random.Range(xmin, xmax), transform.position.y, transform.position.z + Random.Range(ymin, ymax)), transform.rotation);
                i++;
            }
        }
    }
}