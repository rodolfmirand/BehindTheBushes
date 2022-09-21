using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LancaChamasCoolDown : MonoBehaviour
{
    public Image imageCoolDown;
    bool isCooldown = false;
    
    private float cooldownTimer;
    public float cooldownTime;

    public GameObject LancaChamas;
    public bool cdChama;
    public float cdAtualChama;



    void Start()
    {
        imageCoolDown.fillAmount = 0.0f;
    }

    void Update(){
        cdChama = LancaChamas.GetComponent<WeaponController>().coolDown;
        cdAtualChama = LancaChamas.GetComponent<WeaponController>().cdAtualChamas;

          
        if(cdChama == true && cdAtualChama > 0){
            UseSpell();
            
        }

        if(isCooldown){
            ApplyCooldown();
        }

    }

    void ApplyCooldown(){
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0.0f){

            isCooldown = false;
            imageCoolDown.fillAmount = 0.0f;
        }else{

            imageCoolDown.fillAmount =  cooldownTimer / cooldownTime;
        }
    }

    public void UseSpell(){
        

        if(isCooldown == false){
                
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
        
    }

    /*public void CoolDown(bool isCooldown){
        
        if(isCooldown == false){
            
        }

        if(isCooldown){
            skillImage.fillAmount -= 1 / cooldown * Time.deltaTime;

            if(skillImage.fillAmount <= 0){
                skillImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }*/
}
