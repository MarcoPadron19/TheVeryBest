using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    //public GameObject player;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private static int score;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        score = GameManager.score;  //  Update our score continuously.
    }

    void slowDown(int score)
    {
        if (score == 1)
        {
            speed -= 1;
        }

        if (score == 2)
        {
            speed -= 1;
        }

        if (score == 3)
        {
            speed -= 1;
        }

        if (score == 4)
        {
            speed -= 1;
        }

        if (score == 5)
        {
            speed -= 1;
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detected collision between " + gameObject.name + " and " + other.name);
        if(other.gameObject == player)
        {
            Debug.Log("Player fell to their death.");
        }

        player.GetComponent<Health>().Respawn();
    }*/
}
