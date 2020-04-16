using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //SLIME
    //COMPONENTS
    public Rigidbody2D slimeRigidbody;
    public SpriteRenderer slimeRenderer;
    public Animator slimeAnim;
    public GameObject playerObject;

    //VARIABLES
    public float targetDistance;
    public int speed;
    public int health = 100;
    public int enemyDamage = 10;
    public bool isAlive;
    
   

    void Start()
    {
        slimeRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update

    private void Awake()
    {
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        slimeAnim = GetComponent<Animator>();
        slimeAnim.SetBool("IsAlive", true);
    }

    public void FollowPlayer()
    {
        targetDistance = 50;

        if (playerObject != null)
        {
            if (Vector3.Distance(transform.position, playerObject.transform.position) < targetDistance)
            {
                if (transform.position.x < playerObject.transform.position.x)
                {
                    slimeRenderer.flipX = false;
                    speed = 2;
                    slimeRigidbody.velocity = new Vector2(speed, slimeRigidbody.velocity.y);
                   
                }
                else if (transform.position.x > playerObject.transform.position.x)
                {
                    slimeRenderer.flipX = true;
                    speed = 2;
                    slimeRigidbody.velocity = new Vector2(-speed, slimeRigidbody.velocity.y);
                   
                }
            }
        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        {
            if (coll.gameObject.tag == "Player")
            {

                coll.gameObject.SendMessageUpwards("TakeDamage",this.gameObject);
            }
        }
    }

    public void TakeDamage(int playerDamage)
    {
        if (transform.position.x > playerObject.transform.position.x)
        { 
            slimeRigidbody.AddForce(new Vector2(6f, 12f), ForceMode2D.Impulse);
        }
        else
        {
            slimeRigidbody.AddForce(new Vector2(-6f, 12f), ForceMode2D.Impulse);
        }
        
        health -= playerDamage;
        if(health <= 0)
        {
            OnDeath();
        }
    }
     public void OnDeath()
    {
       
        slimeAnim.SetBool("IsAlive", false);
      
        Destroy(gameObject,1.2f);
        this.GetComponent<EnemyScript>().enabled = false;



    }

    // Update is called once per frame
    void Update()
    {
       FollowPlayer();
    }
}
