using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;

public class Player : MonoBehaviour
{
    private Rigidbody2D Rb2D;
    private float movement;
    public float speed;
    public float JumpForce;
    private Animator animator;

    [SerializeField] GameObject door;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject win;
    [SerializeField] GameObject doble;
    [SerializeField] GameObject ControlSign;

    [SerializeField] private TMP_Text keyNumber;

    public bool Grounded = false;

    public bool shoe = false;
    public bool jumpPos;
    private int keyCollectedNumber;
    public bool alive = true;
    private bool  showingSign = false;
    private bool finishedGame = false;
    private bool MirandoDerecha = true;

//    private Vector2 initialPos;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
        void endSign()
        {
            alive = true;
            showingSign = false;
            doble.SetActive(false);
        }

    void takeShoe()
    {
        shoe = true;
        animator.SetBool("HaveShoe", true);
        alive = false;
        showingSign = true;
        Rb2D.velocity = Rb2D.velocity * 0f;
        doble.SetActive(true);
        Invoke("endSign", 3f);
    }

    void gameOver()
    {
        alive = false;
        Rb2D.velocity = Rb2D.velocity * 0f;
        gameover.SetActive(true); 
    }

    void winGame()
    {
        alive = false;
        Rb2D.velocity = Rb2D.velocity * 0f;
        win.SetActive(true);
        finishedGame = true;
        animator.SetBool("isRunning", false);
    }

    void restart()
    {
        SceneManager.LoadScene("Level");
        gameover.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            ControlSign.SetActive(false);
        }

        if (alive)
        {
            void Jump()
            {
                Rb2D.AddForce(Vector2.up * JumpForce);
            };

            if (Physics2D.Raycast(transform.position, Vector3.down, 1f))
            {
                Grounded = true;
                jumpPos = true;
                animator.SetBool("IsGrounded", true);
            }
            else
            {
                Grounded = false;
                animator.SetBool("IsGrounded", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && Grounded)
            {
                Jump();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && Grounded == false && shoe == true && jumpPos == true)
            {
                Jump();
                jumpPos = false;
            };
        }
        if (Input.GetKeyDown(KeyCode.Space) && alive == false && showingSign == false)
        {
            restart();
        }

        if (finishedGame == true && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("mainMenu");
        }
    }



 
    void FixedUpdate()
    {
        if (alive)
        {
            movement = Input.GetAxisRaw("Horizontal");

            Rb2D.velocity = new Vector2(movement * speed, Rb2D.velocity.y);

            orientacion(movement);

            if(movement != 0f)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }

        if(keyCollectedNumber == 4)
        {
            Destroy(door);
        }
    }


    void orientacion(float movement)
    {
        if(MirandoDerecha == true && movement < 0f || MirandoDerecha == false && movement > 0f)
        {
            MirandoDerecha = !MirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            keyCollectedNumber++;
            keyNumber.text = keyCollectedNumber.ToString();
        }

        if (collision.CompareTag("Shoe"))
        {
            takeShoe();
        }

        if (collision.CompareTag("Spike"))
        {
            gameOver();
        };

        if (collision.CompareTag("Finish"))
        {
            winGame();
        }
    }
}
