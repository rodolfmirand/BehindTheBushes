using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public static BoxCollider2D bc; 

    public SpriteRenderer sprite;

    public int maxHealth = 100;
    public int currentHealth;
    public int dmg;

    public HealthBar healthBar;
    
    PlayerController pMove;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //pMove = PlayerController.pMove;

    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Enemy")){
            
            bc.enabled = false;
            StartCoroutine(pMove.DamagePlayer());

            TakeDamage(dmg);

            if(currentHealth == 0){

                Debug.Log("Dead");
            }
        }
    }

    void TakeDamage(int damage){

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
