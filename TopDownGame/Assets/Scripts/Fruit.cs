using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float fruitLife;

    void Update() {
        fruitLife -= Time.deltaTime;

        if(fruitLife <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.CompareTag("Player")){
            
            Destroy(gameObject);

        }

        
    }
}
