using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinnies : MonoBehaviour
{
    public int xspeed;
    public int yspeed;
    public int zspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xspeed, yspeed, zspeed, Space.World);
    }
}
