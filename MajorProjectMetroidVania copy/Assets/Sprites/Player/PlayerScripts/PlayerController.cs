using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerHealth = 100;
   

    public Animator animator;
    public GameObject EnemyObject;
    public Rigidbody2D PlayerRB;


    // Start is called before the first frame update
    void Awake()
    { 
        animator = GetComponent<Animator>();
        animator.SetBool("IsAlive", true);
        PlayerRB = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
     

    }



    public void TakeDamage(GameObject enemyGO)
    {
        float disableTime = 0.8f;
        this.gameObject.SendMessageUpwards("DisableMovement", disableTime);

        int enemyDamage;
        EnemyScript enemyScript = enemyGO.GetComponent<EnemyScript>();
        enemyDamage = enemyScript.enemyDamage;
        Debug.Log("Taking Damage");

        if (transform.position.x > enemyGO.transform.position.x)
        {
            Debug.Log("Force added right");
            PlayerRB.velocity = new Vector2(12f, PlayerRB.velocity.y);
            PlayerRB.AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("Force added left");
            PlayerRB.velocity = new Vector2(-12f, PlayerRB.velocity.y);
            PlayerRB.AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
        }
  
        
        //this.GameObject.findGameObjectsWithTag("Player");
        playerHealth -= enemyDamage;
        if (playerHealth <= 0)
        {
            Death();
        }
    }



    public void Death()
    { 
        this.GetComponent<PlayerMovement>().enabled = false;
        animator.SetBool("IsAlive", false);

        Destroy(gameObject, 2.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
