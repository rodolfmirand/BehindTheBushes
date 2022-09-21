using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public static BoxCollider2D bc; 

    public SpriteRenderer sprite;

    [Header("Vida, Dano causado por inimigos e Cura")]
    public int maxHealth = 100;
    public int currentHealth;
    public int damage;
    public int cure;
    public HealthBar healthBar;

    [Header("Flores")]
    public int flowers;
    public int floresMinimoLanca;
    public int floresMinimoShotgun;
    public Text txtFlores;

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

    [Header("Batatas")]
    public int batatas;
    public int batatasMinimoEscudo;
    public Text txtBatatas;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        flowers = 0;

        lançaChamas.SetActive(false);
        iconeLancaChamas.SetActive(false);

        shotgun.SetActive(false);
        iconeShotgun.SetActive(false);

        escudo.SetActive(false);
        iconeEscudo.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("batataAssada"))
        {
            batatas++;
            txtBatatas.text = ""+batatas;

            if(batatas >= batatasMinimoEscudo)
            {
                escudo.SetActive(true);
                iconeEscudo.SetActive(true);
            }
        }
        if(collision.CompareTag("Enemy")){
            
            bc.enabled = false;
            StartCoroutine(DamagePlayer());

            TakeDamage(damage);

            if(currentHealth <= 22){
                GameManager.instance.GameOver();
                Debug.Log("Dead");
            }
        }
        /*if(collision.CompareTag("FlowerEnemy")){
            
            bc.enabled = false;
            StartCoroutine(DamagePlayer());

            TakeDamage(damage);

            if(currentHealth <= 22){
                GameManager.instance.GameOver();
                Debug.Log("Dead");
            }
        }*/

        if(collision.CompareTag("Spike")){
            
            bc.enabled = false;
            StartCoroutine(DamagePlayer());

            TakeDamage(damage);

            if(currentHealth <= 22){
                GameManager.instance.GameOver();
                Debug.Log("Dead");
            }
        }


        if(collision.CompareTag("Fruit")){

            CureHealth(cure);

        }

        if(collision.CompareTag("Flower")){

            flowers++;

            if(flowers >= floresMinimoLanca)
            {
                iconeLancaChamas.SetActive(true);
                lançaChamas.SetActive(true);
            }

            if(flowers >= floresMinimoShotgun)
            {
                shotgunOn = true;
                shotgun.SetActive(true);    
                iconeShotgun.SetActive(true);
            }

            txtFlores.text = ""+flowers;
        }

    }

    void TakeDamage(int dmg){

        currentHealth -= dmg;

        healthBar.SetHealth(currentHealth);
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

        bc.enabled = true;
    }

    public void ModoCheat()
    {
        currentHealth = 10000;
        iconeLancaChamas.SetActive(true);
        lançaChamas.SetActive(true);
        shotgunOn = true;
        shotgun.SetActive(true);    
        iconeShotgun.SetActive(true);
        escudo.SetActive(true);
        iconeEscudo.SetActive(true);
    }
}
