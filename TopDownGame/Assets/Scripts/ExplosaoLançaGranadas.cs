using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoLançaGranadas : MonoBehaviour
{
    public float vidaExplosao;
    
    void Update()
    {
        vidaExplosao -= Time.deltaTime;

        if(vidaExplosao <= 0)
        {
            Destroy(gameObject);
        }
    }
}
