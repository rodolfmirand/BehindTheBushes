using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor : MonoBehaviour
{
    public PlayerLife player;

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("batataAssada"))
        {
            player.batatas++;
            player.txtBatatas.text = ""+player.batatas;

        }

        if(collision.CompareTag("Fruit"))
        {
            player.CureHealth(player.cure);
        }

        if(collision.CompareTag("Flower")){

            player.flores++;
            player.txtFlores.text = ""+player.flores;
        }
    }
}
