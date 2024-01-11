using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keyCollected : MonoBehaviour
{
    [SerializeField] private TMP_Text keyNumber;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
