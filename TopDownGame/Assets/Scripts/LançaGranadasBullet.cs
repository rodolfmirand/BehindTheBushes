using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LançaGranadasBullet : MonoBehaviour
{
    public float speed;
    public ParticleSystem effect;
    public float bulletLife;
    public GameObject explosao;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        bulletLife -= Time.deltaTime;

        if(bulletLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Enemy")){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);

            Instantiate(explosao, transform.position, transform.rotation);

            EnemyController enemy = collision.GetComponent<EnemyController>();
            
        }

        if(collision.CompareTag("EnemyFruit")){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);

            EnemyFruit enemy = collision.GetComponent<EnemyFruit>();
            
            
        }

        if(collision.CompareTag("FlowerEnemy")){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);

            EnemyFruit enemy = collision.GetComponent<EnemyFruit>();

        }

        if(collision.CompareTag("Map")){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);           
            
        }
    }
}