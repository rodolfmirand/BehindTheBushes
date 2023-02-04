using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigunOnOff : MonoBehaviour
{
    public Sprite on;
    public Sprite off;

    public SpriteRenderer sr;

    public WeaponController minigun;

    void Start()
    {
        sr.sprite = off;
    }

    // Update is called once per frame
    void Update()
    {
        if(minigun.tiroNormal == false)
        {
            sr.sprite = on;
        }else{
            sr.sprite = off;
        }
    }
}
