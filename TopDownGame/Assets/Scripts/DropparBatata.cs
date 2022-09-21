using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropparBatata : MonoBehaviour
{
    public GameObject batata;
    public GameObject batataAssada;
    public float vidaBatata;

    void Start()
    {
        
    }

    void Update()
    {
        vidaBatata = batata.GetComponent<EnemyController>().health;

        if(vidaBatata <= 0)
        {
            Instantiate(batataAssada, transform.position, Quaternion.Euler(0f, 0f, 0f));
        }
    }
}
