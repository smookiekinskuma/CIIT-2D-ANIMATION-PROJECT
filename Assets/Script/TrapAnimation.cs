using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimation : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement playerMovement;
    public int TrapDamage;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("IsActive", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("IsActive", false);
        }
    }

    public void PlayerDamage()
    {
        //playerMovement.healthPoints--;
        playerMovement.healthPoints = playerMovement.healthPoints - TrapDamage;
    }
}
