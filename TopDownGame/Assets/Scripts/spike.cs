using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public float speed;

    public float tempoDeVida;

    [SerializeField] ParticleSystem effect;

    void Start()
    {
        Destroy(this.gameObject, tempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }

        if(collision.CompareTag("EnemyFruit"))
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }

        if(collision.CompareTag("FlowerEnemy"))
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }
        
        if(collision.CompareTag("Map"))
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }

        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(effect, transform.position, transform.rotation);
        }
    }
}
