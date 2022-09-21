using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public Animator animator;


    private void LateUpdate() {
        Vector2 velocidade = this.rb.velocity;

        if((velocidade.x != 0) || (velocidade.y != 0)){
            this.animator.SetBool("Run",true);
        }else{
            this.animator.SetBool("Run",false);
        }

        if(velocidade.x > 0){
            this.sr.flipX = false;
        }else if(velocidade.x < 0){
            this.sr.flipX = true;
        }
    }
}
