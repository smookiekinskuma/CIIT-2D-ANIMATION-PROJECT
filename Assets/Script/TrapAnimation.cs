using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapAnimation : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement playerMovement;
    public int TrapDamage;
    public bool IsPlayerOnTop;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerOnTop = true;
            anim.SetBool("IsActive", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsPlayerOnTop = false;
            anim.SetBool("IsActive", false);
        }
    }

    public void PlayerDamage()
    {
        //playerMovement.healthPoints--;
        if (IsPlayerOnTop)
        {
            playerMovement.healthPoints = playerMovement.healthPoints - TrapDamage;
        }

        

    }

    private void Update()
    {
        
    }
}
