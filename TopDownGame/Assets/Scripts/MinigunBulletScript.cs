using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBulletScript : MonoBehaviour
{
    public float speed;
    public ParticleSystem effect;
    public float bulletLife;

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
            
        }

        if(collision.CompareTag("Map")){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);           
            
        }

        if(collision.CompareTag("Cipo")){
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        } 
    }
}
