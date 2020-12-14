using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // puts the character contoller component in the inspector so it can be used later
    public CharacterController controller;
    // horizontal movement is multiplied by this
    public float speed = 12f;
    //downwards acceleration
    public float gravity = -9.81f;
    // this is the groundCheck game object which is a child of the firstPersonPlayer
    public Transform groundCheck;
    //if the distance from the ground check gameobject 
    public float groundDistance = 0.4f;
    // not sure what this does
     public LayerMask groundMask;
    // jumping multiplies by this value
    public float jumpheight = 2f;
    // the vector for the player to be moving
    public Vector3 move;

    

    Vector3 velocity;
    bool isGrounded;

    

    // Update is called once per frame
    void Update()
    {
        // projects a sphere with the radius of 'groundDidstance' around the groundcheck gameobject and if it intersects with an object with the layer 'Ground' the object is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //slows speed to 4 when left shift is pressed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 4f;
        }
        // upon letting go of shift speed is put back to normal
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        // this makes the player keep falling to the ground when the player is percived as grounded as it's classed as grounded before it touches the ground when player reaches the ground as y.velocity is 0 it stops
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // these are referancing things in unity and i can't remeber where they are in unity  but they basicly just get the x and z axis from the player they change based of the players rotation
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //not sure why this is transform.right and also forward 
        move = transform.right * x + transform.forward * z;
        //controller.Move is from the character controller
        controller.Move(move * speed * Time.deltaTime);
        // if grounded jumps when pressing space
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {  
            // accelrates player downwards
            velocity.y = -2f;
            // accelrates player up
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        // * by time.delta time is needed to keep movement dependant of framerate
        velocity.y += gravity * Time.deltaTime;
        //controller.Move is from the character controller not sure how this works exactly but it makes the player move
        controller.Move(velocity * Time.deltaTime);
    }
}
