using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerHardcore : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemy;

    public float tempoAtual;
    public float tempoReset;

    public float tempoAtualSpawn;
    public float dificuldade;


    void Start()
    {   
        tempoAtual = tempoReset;
        tempoAtualSpawn = dificuldade;
        //dificuldade = 1.5f;
        //InvokeRepeating("SpawnEnemies", 0.5f, dificuldade);
    }

    void Update()
    {       
        tempoAtual -= Time.deltaTime;
        tempoAtualSpawn -= Time.deltaTime;

        if(tempoAtual <= 0)
        {
            tempoAtual = tempoReset;

            dificuldade = dificuldade - 0.1f;   
            
        }

        if(tempoAtualSpawn <= 0)
        {   
            tempoAtualSpawn = dificuldade;
            
            SpawnEnemiesHardcore();
        }
        

        //InvokeRepeating("SpawnEnemies", 0.5f, dificuldade);
        

        /*if(tempoAtual <= 0)
        {   
            tempoAtual = tempoReset;
            dificuldade = dificuldade - 0.3f;
        }*/
        
    }

    void SpawnEnemiesHardcore(){
        int objetoAleatorio = Random.Range(0,enemy.Length);

        int index = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy[objetoAleatorio], spawnPoints[index].position, Quaternion.identity);
    }


}
