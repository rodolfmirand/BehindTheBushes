using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

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
}
