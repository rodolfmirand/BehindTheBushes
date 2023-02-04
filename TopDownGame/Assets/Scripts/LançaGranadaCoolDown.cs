using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LançaGranadaCoolDown : MonoBehaviour
{
    public Image imageCoolDown;
    bool isCooldown = false;
    
    private float cooldownTimer;
    public float cooldownTime;

    public GameObject lancaGranada;
    public bool cdTiro;
    public float cdAtualTiro;



    void Start()
    {
        imageCoolDown.fillAmount = 0.0f;
    }

    void Update(){
        cdTiro = lancaGranada.GetComponent<WeaponController>().coolDownLancaGranada;
        cdAtualTiro = lancaGranada.GetComponent<WeaponController>().cdAtualLancaGranada;

          
        if(cdTiro == true && cdAtualTiro > 0){
            UseSpell();
            
        }

        if(isCooldown){
            ApplyCooldown();
        }

    }

    void ApplyCooldown(){
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0){

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
}
