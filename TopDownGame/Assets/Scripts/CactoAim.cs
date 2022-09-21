using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactoAim : MonoBehaviour
{
    GameObject player;

    public GameObject spike;

    public Transform spawnSpike;

    public float tempMaxTiro;
    public float tempAtualTiro;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tempAtualTiro = tempMaxTiro;
    }

    void Update()
    {
       Aim();
       Shoot();
    }

    void Aim(){

        Vector3 playerPos = player.transform.position;
        Vector3 screePoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(playerPos.x - screePoint.x, playerPos.y - screePoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        //sr.flipY = (playerPos.x < screePoint.x);
    }

    void Shoot(){
        tempAtualTiro -= Time.deltaTime;

        if(tempAtualTiro <= 0){

            Instantiate(spike, spawnSpike.position, transform.rotation);
            tempAtualTiro = tempMaxTiro;
        }

    }
}
