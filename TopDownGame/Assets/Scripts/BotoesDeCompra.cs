using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesDeCompra : MonoBehaviour
{
    public PlayerLife player;
    public WeaponController weapon;
    
    [Header("Lança Chamas")]
    public GameObject lançaChamas;
    public GameObject iconeLancaChamas;

    [Header("Espingarda")]
    public GameObject shotgun;
    public GameObject iconeShotgun; 
    public bool shotgunOn = false;  

    [Header("Escudo")]
    public GameObject escudo;
    public GameObject iconeEscudo;

    [Header("Lança Granadas")]
    public GameObject lancaGranadas;
    public GameObject iconeLancaGranadas;

    private bool espingardaComprada = false;
    private bool lancaChamasComprado = false;
    private bool escudoComprado = false;
    private bool lancaGranadaComprado = false;

    [Header("Minigun")]
    public WeaponController minigun;
    public GameObject iconeMinigun;
    bool minigunComprada = false;

    [Header("Sons")]
    public AudioSource somComprarSG;
    public AudioSource somComprarEscudo;
    public AudioSource somComprarLancador;
    public AudioSource somComprarMinigun;
    public AudioSource somComprarLancaChamas;

    void Start()
    {
        
    }

    public void ComprarEspingarda()
    {
        if(espingardaComprada == false)
        {

            if(player.flores >= 10)
            {
                espingardaComprada = true;
                somComprarSG.Play();

                player.flores = player.flores - 10;
                player.txtFlores.text = ""+ player.flores;

                player.shotgunOn = true;
                shotgun.SetActive(true);
                iconeShotgun.SetActive(true);
            } 
        }
    }

    public void ComprarLancaChamas()
    {
        if(lancaChamasComprado == false) 
        {
            
            if(player.flores >= 10)
            {
                lancaChamasComprado = true;
                somComprarLancaChamas.Play();

                player.flores = player.flores - 10;
                player.txtFlores.text = ""+ player.flores;

                iconeLancaChamas.SetActive(true);
                lançaChamas.SetActive(true);
            }
        }
    }

    public void ComprarEscudo()
    {
        if(escudoComprado == false)
        {
            if(player.batatas >= 10)
            {
                escudoComprado = true;
                somComprarEscudo.Play();
                player.batatas = player.batatas - 10;
                player.txtBatatas.text = ""+ player.batatas;

                escudo.SetActive(true);
                iconeEscudo.SetActive(true);
            }
        }
    }

    public void ComprarLancaGranadas()
    {
        if(lancaGranadaComprado == false)
        {
            
            if(player.batatas >= 10)
            {

                lancaGranadaComprado = true;
                somComprarLancador.Play();
                player.batatas = player.batatas - 10;
                player.txtBatatas.text = ""+ player.batatas;

                lancaGranadas.SetActive(true);
                iconeLancaGranadas.SetActive(true);
                weapon.granadaOn = true;
            }
        }
    }

    public void ComprarGranada()
    {
        if(player.flores >= 15)
        {
            player.flores = player.flores - 15;
            player.txtFlores.text = ""+player.flores;

            weapon.quantidadeTirosLancaGranada = weapon.quantidadeTirosLancaGranada + 5;

            weapon.txtGranada.text = ""+ weapon.quantidadeTirosLancaGranada;
        }
    }

    public void ComprarVida()
    {
        if(player.flores >= 30)
        {
            player.flores = player.flores - 30;
            player.txtFlores.text = ""+player.flores;

            player.currentHealth = player.currentHealth + (player.maxHealth/2);
            player.healthBar.SetHealth(player.currentHealth);
        }
    }

    public void ComprarMinigun()
    {
        if(minigunComprada == false)
        {
    
            if(player.batatas >= 25)
            {
                minigunComprada = true;
                somComprarMinigun.Play();
                minigun.minigunOn = true;
                
                player.batatas = player.batatas - 25;
                player.txtBatatas.text = ""+player.batatas;

                iconeMinigun.SetActive(true);
                minigun.minigunOn = true;
                minigun.quantidadeTirosMinigun = minigun.quantidadeMaxTirosMinigun;
                minigun.txtMinigun.text = ""+minigun.quantidadeMaxTirosMinigun;
            }
        }
    }
}
