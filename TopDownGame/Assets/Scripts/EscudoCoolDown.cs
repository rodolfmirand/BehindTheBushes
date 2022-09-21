using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscudoCoolDown : MonoBehaviour
{
    public Image imageCoolDown;
    bool isCooldown = false;
    
    private float cooldownTimer;
    public float cooldownTime;

    public GameObject escudo;
    public bool escAtivado;
    public float cdAtualEscudo;



    void Start()
    {
        imageCoolDown.fillAmount = 0.0f;
    }

    void Update(){
        escAtivado = escudo.GetComponent<WeaponController>().escudoAtivado;
        cdAtualEscudo = escudo.GetComponent<WeaponController>().tempAtualEscudo;

          
        if(escAtivado == false && cdAtualEscudo > 0){
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
}
