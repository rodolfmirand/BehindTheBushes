using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGunCoolDown : MonoBehaviour
{
    public WeaponController minigun;
    public Image imageCoolDown;
    bool isCD = false;
    public bool minigunAtira;

    private float cooldownTimer;
    public float cooldownTime;

    void Start()
    {
        imageCoolDown.fillAmount = 0.0f;
        minigunAtira = true;
    }

    void Update()
    {
        
        if(minigun.quantidadeTirosMinigun <= 0)
        {
            CoolDownMax();
        }

        if(isCD)
        {
            UseSpell();
        }
        
    }
    void UseSpell()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0)
        {
            minigunAtira = true;
            minigun.quantidadeTirosMinigun = minigun.quantidadeMaxTirosMinigun;
            isCD = false;
            imageCoolDown.fillAmount = 0.0f;
            minigun.txtMinigun.text = ""+minigun.quantidadeMaxTirosMinigun;
        }else
        {
            imageCoolDown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    void CoolDownMax()
    {
        if(isCD == false)
        {
            isCD = true;
            cooldownTimer = cooldownTime;
            minigunAtira = false;
            minigun.tiroNormal = true;
        }
    }
}
