using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class controller : MonoBehaviour

{
    //movement speed variable
    public float movespeed;
    //roation (lookaround) speed
    public float rspeed;
    // roation on axes
    public float rotx;
    public float roty;
    // jump power
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKey (KeyCode.LeftShift) && Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movespeed * 2.5f;
        } else if(Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift)) {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movespeed;
        } else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movespeed;
        } 

        if(Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movespeed;
        }else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movespeed;
        }
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y <= 1.05f)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
            }
        }
        rotx -= Input.GetAxis("Mouse Y") * Time.deltaTime * rspeed;
        roty += Input.GetAxis("Mouse X") * Time.deltaTime * rspeed;

        if(rotx < -90)
        {
            rotx = -90;
        }else if (rotx > 90)
        {
            rotx = 90;
        }

        transform.rotation = Quaternion.Euler (0, roty, 0);
        GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler(rotx, roty, 0);
    }

}
