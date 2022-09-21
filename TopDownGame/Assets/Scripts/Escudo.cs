using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public int vidaMaxEscudo;
    public int vidaAtualEscudo;
    public int danoEscudo;

    public ShieldBar shieldBar;


    void Start()
    {
        vidaAtualEscudo = vidaMaxEscudo;
        shieldBar.SetMaxShield(vidaMaxEscudo);

    }
    private void Update() {
        shieldBar.SetShield(vidaAtualEscudo);
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("DeadEnemy"))
        {
            vidaAtualEscudo -= danoEscudo;
        }
        if(collision.CompareTag("Enemy"))
        {
            vidaAtualEscudo -= danoEscudo;

        }
    }

    public void SetVidaEscudo()
    {
        vidaAtualEscudo = vidaMaxEscudo;
    }
}
