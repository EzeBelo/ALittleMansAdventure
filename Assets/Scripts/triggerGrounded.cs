using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class triggerGrounded : MonoBehaviour
{
    public Player player;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Floor"))
        {
            player.Grounded = true;
        } else
        {
            player.Grounded = false;
        }

        /*
        if (collision.CompareTag("Floor"))
        {
            player.Grounded = true;
        } else if(collision.CompareTag("Untagged"))
        {
            player.Grounded = false;
        }

         */
    }
        



}
