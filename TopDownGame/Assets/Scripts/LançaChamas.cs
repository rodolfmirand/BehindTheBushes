using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LançaChamas : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] ParticleSystem effect;

    public int damage;

    void Start(){

    }

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Enemy")){
            EnemyController enemy = collision.GetComponent<EnemyController>();

            if(enemy != null){
                enemy.TakeDamage(damage);
            }
        }

        if(collision.CompareTag("EnemyFruit")){
            EnemyFruit enemy = collision.GetComponent<EnemyFruit>();

            if(enemy != null){
                enemy.TakeDamage(damage);
            }
        }
        
        Instantiate(effect, transform.position, transform.rotation);
    }
}
