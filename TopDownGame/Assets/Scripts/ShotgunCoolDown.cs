using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunCoolDown : MonoBehaviour
{
    public Image imageCoolDown;
    bool isCooldown = false;
    
    private float cooldownTimer;
    public float cooldownTime;

    public GameObject Shotgun;
    public bool cdTiro;
    public float cdAtualTiro;

    public AudioSource sgReaload;
    public bool sgRealoadOn;

    void Start()
    {
        imageCoolDown.fillAmount = 0.0f;
        sgRealoadOn= true;
    }

    void Update(){
        cdTiro = Shotgun.GetComponent<WeaponController>().coolDownShotgun;
        cdAtualTiro = Shotgun.GetComponent<WeaponController>().cdAtualShotgun;

          
        if(cdTiro == true && cdAtualTiro > 0){
            UseSpell();
            
        }

        if(isCooldown){
            cooldownTimer -= Time.deltaTime;

            if(sgRealoadOn)
            {
                sgReaload.Play();
                sgRealoadOn = false;
            }

            if(cooldownTimer < 0.0f)
            {
                sgRealoadOn = true;
                isCooldown = false;
                imageCoolDown.fillAmount = 0.0f;
            }else{
                imageCoolDown.fillAmount =  cooldownTimer / cooldownTime;
            }
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
