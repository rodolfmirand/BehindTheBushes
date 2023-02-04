using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float playerMoveSpeedMax;
    public AudioSource somPassos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMoveSpeedMax = moveSpeed;
    }

    void Update()
    {   
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            somPassos.enabled = true;
        }else{
            somPassos.enabled = false;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direcao = new Vector2(horizontal,vertical);
        direcao = direcao.normalized;

        this.rb.velocity = direcao * this.moveSpeed;

    }
}
