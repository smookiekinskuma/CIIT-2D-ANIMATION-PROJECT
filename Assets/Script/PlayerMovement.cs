using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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

    //Coin count
    public int coincounter;

    //health
    public int healthPoints;

    //Text
    public TextMeshProUGUI HealthText, CoinText;
    
    //Timer
    public float normalSpeed, boostedSpeed, speedCoolDown;

    public GameObject Win, Game;


    // Start is called before the first frame update
    void Start()
    {
        
        
        normalSpeed = moveSpeed;
        //Gets the Rigidbody Component from the player
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = healthPoints.ToString();
        CoinText.text = coincounter.ToString();

        //Gets the horizontal string on animator and adding the movement input x into it
        anim.SetFloat("Horizontal", movementInput.x );
        //Gets the horizontal string on animator and adding the movement input y into it
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

        if (coincounter == 210)
        {
            Game.SetActive(false);
            Win.SetActive(true);
        }

        //OR - CTRL + K + C = COMMENT ALL
        //S Down
        //if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("forward");
        //}
        //if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    anim.enabled = false;
        //}

        //W Up
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("backward");
        //}
        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    anim.enabled = false;
        //}

        //D Right
        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("right");
        //}
        //if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    anim.enabled = false;
        //}

        //A Left
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.enabled = true;
        //    anim.SetTrigger("left");
        //}
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    anim.enabled = false;
        //}

    }

    //Collecting Coins
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coincounter++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Chest"))
        {
            coincounter++;
            coincounter++;
            coincounter++;
            coincounter++;
            coincounter++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Health"))
        {
            healthPoints++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Speed"))
        {
            moveSpeed = boostedSpeed;
            Destroy(collision.gameObject);
            StartCoroutine("SpeedDuration");
        }
    }

    IEnumerator SpeedDuration()
    {
        yield return new WaitForSeconds(speedCoolDown);
        moveSpeed = normalSpeed;
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
    
    public void ExitButton()
    {
        Application.Quit();
    }

    //FPS Frames Per Second
}
