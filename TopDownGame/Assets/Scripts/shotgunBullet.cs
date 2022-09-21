using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgunBullet : MonoBehaviour
{
    public float dir;
    public float speed;
    public Vector2 direction;
    public Rigidbody2D rb;
    public float normalization;
    public Vector2 normalizedOrientation;

    void Start() 
    {
        normalization = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        normalizedOrientation = new Vector3(direction.x / normalization, direction.y / normalization);

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() 
    {
        //rb.velocity = new Vector3(dir * speed * normalizedOrientation,x, rb.velocity.y * normalizedOrientation.y, 0);
        rb.velocity = new Vector2(dir * speed * normalizedOrientation.x, normalizedOrientation.y * speed);
    }
}
