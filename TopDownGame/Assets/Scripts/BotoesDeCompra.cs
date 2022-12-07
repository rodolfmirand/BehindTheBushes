using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotoesDeCompra : MonoBehaviour
{
    public PlayerLife player;
    
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
    public GameObject granadas;
    public GameObject iconeGranadas;

    void Start()
    {
        
    }

    public void ComprarEspingarda()
    {
        if(player.flowers >= 10)
        {
            player.flowers = player.flowers - 10;
            player.txtFlores.text = ""+ player.flowers;

            player.shotgunOn = true;
            shotgun.SetActive(true);
            iconeShotgun.SetActive(true);
            
        }
    }

    public void ComprarLancaChamas()
    {
        if(player.flowers >= 10)
        {
            player.flowers = player.flowers - 10;
            player.txtFlores.text = ""+ player.flowers;

            iconeLancaChamas.SetActive(true);
            lançaChamas.SetActive(true);
        }
    }

    public void ComprarEscudo()
    {
        if(player.batatas >= 10)
        {
            player.batatas = player.batatas - 10;
            player.txtBatatas.text = ""+ player.batatas;

            escudo.SetActive(true);
            iconeEscudo.SetActive(true);
        }
    }

    public void ComprarLancaGranadas()
    {

    }
}
