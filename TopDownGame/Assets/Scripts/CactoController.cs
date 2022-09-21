using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactoController : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject player;
    Animator animator;
    bool isAlive = true;

    public int vidaMax;
    public int vidaAtual;
    public int danoLevado;

    public GameObject spike;
    public Transform pontoSpawnSpike;

    private bool enconstandoLança;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();   

        vidaAtual = vidaMax;

        enconstandoLança = false;
    }

    void Update()
    {
        if(player != null && isAlive){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        if(enconstandoLança == true)
        {
            vidaAtual--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("Bullet")){
            TakeDamage(danoLevado);

            if(vidaAtual <= 0){
                
                gameObject.tag = "DeadEnemy";
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
                Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
                
                GameManager.instance.AumentarPontuacao();
                
                animator.SetTrigger("Dead");
                isAlive = false;
                Shoot();
                Destroy(gameObject, 0.8f);

            }
            
        }

        if(collision.CompareTag("LançaChamas")){
            enconstandoLança = true;
            TakeDamage(danoLevado);

            if(vidaAtual <= 0){

                gameObject.tag = "DeadEnemy";
                
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
                Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
                
                GameManager.instance.AumentarPontuacao();
                
                animator.SetTrigger("Dead");
                isAlive = false;
                Shoot();
                Destroy(gameObject, 0.8f);
            }
        }else{
            enconstandoLança = false;
        }

        if(collision.CompareTag("Escudo"))
        {
            TakeDamage(danoLevado);

            if(vidaAtual <= 0){
                
                gameObject.tag = "DeadEnemy";
                Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
                Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
                
                GameManager.instance.AumentarPontuacao();
                
                animator.SetTrigger("Dead");
                isAlive = false;
                Shoot();
                Destroy(gameObject, 0.8f);

            }
        }
    }


    public void TakeDamage(int dmg){

        vidaAtual -= dmg;
    }

    private void Shoot()
    {
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,0f));
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,45f));
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,90f));
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,135f));
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,180f));
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,225f));
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,270f));
        Instantiate(spike, pontoSpawnSpike.position, Quaternion.Euler(0f,0f,315f));
    }
}
