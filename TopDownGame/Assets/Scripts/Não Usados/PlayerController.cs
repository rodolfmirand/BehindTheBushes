using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed;
    public SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {   
       
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direcao = new Vector2(horizontal,vertical);
        direcao = direcao.normalized;

        this.rb.velocity = direcao * this.moveSpeed;


    }

    public IEnumerator DamagePlayer(){

        sprite.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1f, 1f, 1f, 1f);

        for(int i = 0; i < 7; i++){

            sprite.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled = true; 
            yield return new WaitForSeconds(0.15f);
        }

        PlayerHealth.bc.enabled = true;
    }
}
