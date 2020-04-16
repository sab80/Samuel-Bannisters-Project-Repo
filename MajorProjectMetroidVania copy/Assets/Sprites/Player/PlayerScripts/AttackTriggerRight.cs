using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerRight : MonoBehaviour
{
    public int playerDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Enemy"))
        {
            Debug.Log("Ontrigger");
            col.SendMessageUpwards("TakeDamage", playerDamage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
