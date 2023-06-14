using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Variable for our speed modifier
    public float moveSpeed;

    //Variable for out input
    //x and y (Vector2) x, y and z (Vector 3)
    public Vector2 movementInput;

    //Variable for our rigidbody2d
    public Rigidbody2D rigidBody;

    //variable for animator
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //Gets the Rigidbody Component from the player
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //S Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("forward");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {

        }

        //W Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("backward");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {

        }

        //D Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetTrigger("right");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {

        }

        //A Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("left");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

        }
    }

    //Update that handles physics (every 0.01)
    private void FixedUpdate()
    {
        //Adds a velocity on our rigidbody
        rigidBody.velocity = movementInput * moveSpeed; 
    }

    //Converts out inputs to vectors
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    //FPS Frames Per Second
}
