using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public SpriteRenderer mySprite;
    private Animator anim;

    public int health;
    public int attackDamage;
    public float critDamagePercent;
    public float critChance;
    private bool attacking;
    private float attackDuration = 0;
    private float attackCD = 0.3f;


    private bool checkIsFlipped;
    public GameObject RightCollider;
    public GameObject LeftCollider;

   
   
 

    private void Awake()
    {
        mySprite = this.gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        checkIsFlipped = mySprite.flipX;
        RightCollider = GameObject.Find("PlayerAttackTriggerRight");
        LeftCollider = GameObject.Find("PlayerAttackTriggerLeft");
        RightCollider.GetComponent<Collider2D>().enabled = false;
        LeftCollider.GetComponent<Collider2D>().enabled = false;


    }


    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        attackDamage = 10;
        critDamagePercent = 1f;
        critChance = 0.1f;
    }

    public void Attack()
    {
        if (Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackDuration = attackCD;
            checkIsFlipped = mySprite.flipX;
            Debug.Log(checkIsFlipped);
            if (checkIsFlipped)
            {
                LeftCollider.GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                RightCollider.GetComponent<Collider2D>().enabled = true;
            }
           

        }

        if (attacking)
        {
            if(attackDuration > 0)
            {
                attackDuration -= Time.deltaTime;

            }
            else
            {
                attacking = false;
                RightCollider.GetComponent<Collider2D>().enabled = false;
                LeftCollider.GetComponent<Collider2D>().enabled = false;
               
            }
        }
        anim.SetBool("IsAttacking", attacking);
    }

    public void CritsAttack()
    {

    }

    public void Death()
    {

    }

    public void Respawn()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
}
