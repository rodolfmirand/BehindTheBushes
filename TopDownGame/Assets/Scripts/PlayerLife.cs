using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public static PolygonCollider2D colisorGeral;

    public SpriteRenderer sprite;

    public ParticleSystem efeitoCipo;

    bool morreu = false;

    public GameObject telaGameOver;

    public AudioSource levandoDanoAudioSource;
    public AudioClip[] levandoDano;
    public AudioSource morrendo;

    public Transform player;
    
    [Header("PlayerMove")]
    public PlayerMove playerMove;

    public WeaponController weapon;

    [Header("Vida, Dano causado por inimigos e Cura")]
    public int maxHealth = 100;
    public int currentHealth;
    public int damage;
    public int cure;
    public HealthBar healthBar;
    public float segundosStunnado;

    [Header("Flores")]
    public int flores;
    //public int floresMinimoLanca;
    //public int floresMinimoShotgun;
    public Text txtFlores;

    [Header("Batatas")]
    public int batatas;
    //public int batatasMinimoEscudo;
    public Text txtBatatas;

    [Header("Lança Chamas")]
    public GameObject lançaChamas;
    public GameObject iconeLancaChamas;

    [Header("Shotgun")]
    public GameObject shotgun;
    public GameObject iconeShotgun; 
    public bool shotgunOn = false;  

    [Header("Escudo")]
    public GameObject escudo;
    public GameObject iconeEscudo;

    [Header("Lança Granadas")]
    public GameObject lancaGranada;
    public GameObject iconeLancaGranada;

    [Header("Minigun")]
    public GameObject iconeMinigun;

    void Start()
    {
        colisorGeral = GetComponent<PolygonCollider2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        lançaChamas.SetActive(false);
        iconeLancaChamas.SetActive(false);

        shotgun.SetActive(false);
        iconeShotgun.SetActive(false);

        escudo.SetActive(false);
        iconeEscudo.SetActive(false);

        lancaGranada.SetActive(false);
        iconeLancaGranada.SetActive(false);


    }

    private void Update() {
        if(currentHealth <= 22){
            
            healthBar.SetHealth(currentHealth);
            GameManager.instance.GameOver();
            GameManager.instance.gameoverOn = true;
            Debug.Log("Dead");
            morreu = true;
        }
        if(morreu)
        {
            morrendo.Play();
        }

    
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Enemy")){
            
            colisorGeral.enabled = false;
            StartCoroutine(DamagePlayer());

            TakeDamage(damage);

           
        }
        if(collision.CompareTag("FlowerEnemy")){
            
            colisorGeral.enabled = false;
            StartCoroutine(DamagePlayer());

            TakeDamage(damage);
            
        }

        if(collision.CompareTag("Spike")){
            
            colisorGeral.enabled = false;
            StartCoroutine(DamagePlayer());

            TakeDamage(damage);
            
        }

        if(collision.CompareTag("Fruit")){

            CureHealth(cure);

        }

        if(collision.CompareTag("Cipo"))
        {
            
            StartCoroutine(StunPlayer());
            Instantiate(efeitoCipo, player.position, player.rotation);
        }

    }

    public IEnumerator StunPlayer()
    {
        playerMove.moveSpeed = 0;
        
        yield return new WaitForSeconds(segundosStunnado);
        
        playerMove.moveSpeed = playerMove.playerMoveSpeedMax;
        
    }

    void TakeDamage(int dmg){

        currentHealth -= dmg;

        healthBar.SetHealth(currentHealth);

        if(!telaGameOver.activeInHierarchy)
        {
            levandoDanoAudioSource.PlayOneShot(levandoDano[Random.Range(0,2)]);
        }
        
    }

    public void CureHealth(int cr){
        
        if(currentHealth + cr <= maxHealth){

            currentHealth += cr;
        }else{

            currentHealth = maxHealth;
        }
        
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator DamagePlayer(){

        sprite.color = new Color(1f, 0, 0, 1f);
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(1f, 1f, 1f, 1f);

        for(int i = 0; i < 4; i++){

            sprite.enabled = false;
            yield return new WaitForSeconds(0.15f);
            sprite.enabled = true; 
            yield return new WaitForSeconds(0.15f);
        }

        colisorGeral.enabled = true;
    }

    public void ModoCheat()
    {
        currentHealth = 10000;
        healthBar.SetHealth(currentHealth);
        iconeLancaChamas.SetActive(true);
        lançaChamas.SetActive(true);
        shotgunOn = true;
        shotgun.SetActive(true);    
        iconeShotgun.SetActive(true);
        escudo.SetActive(true);
        iconeEscudo.SetActive(true);
        iconeLancaGranada.SetActive(true);
        lancaGranada.SetActive(true);
        weapon.granadaOn = true;
        batatas +=100;
        txtBatatas.text = ""+batatas;
        flores+=100;
        txtFlores.text = ""+flores;
        iconeMinigun.SetActive(true);
        weapon.minigunOn = true;
        weapon.quantidadeTirosMinigun = weapon.quantidadeMaxTirosMinigun;
    }
}
