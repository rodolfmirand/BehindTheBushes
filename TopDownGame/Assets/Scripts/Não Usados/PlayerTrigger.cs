using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private PlayerController player;

    void Awake(){

        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
}
