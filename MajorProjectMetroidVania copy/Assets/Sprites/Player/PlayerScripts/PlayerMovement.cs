using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 8;
    public int jumpHeight = 5;
    public Rigidbody2D PlayerRigidbody;
    public GameObject GO;
    public Animator animator;
    private Vector3 PlayerVector;
    public SpriteRenderer mySprite;
    public bool hasDoubleJumped = false;
    private bool onGround;
    private float horizontalMovement;

    //public int playerHealth = 100;
    // Start is called before the first frame update

    void Start()
    {
        animator.SetBool("IsAlive", true);
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        mySprite = this.gameObject.GetComponent<SpriteRenderer>();
        GO = GetComponent<GameObject>();
        
    }



    public void MovePlayer()
    {
        //PlayerRigidbody.velocity = new Vector2(horizontalMovement * moveSpeed, PlayerRigidbody.velocity.y);
        //PlayerRigidbody.MovePosition(transform.position + PlayerVector * moveSpeed * Time.deltaTime, PlayerRigidbody.velocity.y);
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0f), ForceMode2D.Impulse);
        PlayerVector = Vector3.zero;
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (horizontalMovement > 0 || horizontalMovement < 0)
        {
            animator.SetBool("Ismoving", true);
            PlayerRigidbody.velocity = new Vector2(horizontalMovement * moveSpeed, PlayerRigidbody.velocity.y);

            if (horizontalMovement < 0)
            {
                mySprite.flipX = true;
            }
            else
            {
                mySprite.flipX = false;
            }
        }
        else
        {
            PlayerRigidbody.velocity = new Vector2(0, PlayerRigidbody.velocity.y);
            animator.SetBool("Ismoving", false);
        }
    }


    void OnCollisionEnter2D(Collision2D Collision)
    {

        if (Collision.gameObject.tag == "Ground")
        {
            animator.SetBool("JumpPress", false);
            animator.SetBool("doubleJump", false);
            onGround = true;

        }
    }


    void Jump()
    {

        if (Input.GetButtonDown("Jump") && onGround == false && hasDoubleJumped == false)
        {
            Debug.Log("lol");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
            animator.SetBool("doubleJump", true);
            hasDoubleJumped = true;
        }

        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
            animator.SetBool("JumpPress", true);
            onGround = false;
            hasDoubleJumped = false;
        }



    }

    public void DisableMovement(float time)
    {
        //This isnt my code.
        enabled = false;
        // If we were called multiple times, reset timer.
        CancelInvoke("Enable");
        // Note: Even if we have disabled the script, Invoke will still run.
        Invoke("EnableMovement", time);
    }

    public void EnableMovement()
    {
        enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }

}