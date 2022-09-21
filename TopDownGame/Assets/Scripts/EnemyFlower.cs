using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlower : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    Animator animator;
    bool isAlive = true;

    public GameObject dropItem;

    public int health;
    public int damage;

    public static BoxCollider2D bc;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();   

        bc = this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(player != null && isAlive){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Bullet")){
            TakeDamage(damage);

            if(health <= 0){
                gameObject.tag = "DeadEnemy";
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
                Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
                
                GameManager.instance.AumentarPontuacao();
                
                animator.SetTrigger("Dead");
                isAlive = false;

                Instantiate(dropItem, transform.position, Quaternion.Euler(0f, 0f, 0f));

                Destroy(gameObject, 0.4f);
            }
            
            
        }

        if(collision.CompareTag("LançaChamas")){
            TakeDamage(damage);

            if(health <= 0){
                gameObject.tag = "DeadEnemy";
                
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
                Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
                
                GameManager.instance.AumentarPontuacao();
            
                animator.SetTrigger("Dead");
                isAlive = false;

                Instantiate(dropItem, transform.position, Quaternion.Euler(0f, 0f, 0f));

                Destroy(gameObject, 0.4f);
            }
            
        }

        if(collision.CompareTag("Escudo"))
        {
            TakeDamage(damage);

            if(health <= 0){
                
                gameObject.tag = "DeadEnemy";
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
                Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
                
                GameManager.instance.AumentarPontuacao();
                
                animator.SetTrigger("Dead");
                isAlive = false;
                
                Destroy(gameObject, 0.8f);

            }
        }

        if(collision.CompareTag("Spike")){
            TakeDamage(damage);

            if(health <= 0){
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
                Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
                
                GameManager.instance.AumentarPontuacao();
                
                animator.SetTrigger("Dead");
                isAlive = false;

                Destroy(gameObject, 0.4f);
            }
        }
        

    }

    public void TakeDamage(int dmg){

        health -= dmg;
    }

}
