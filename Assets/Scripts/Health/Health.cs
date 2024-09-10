using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Animator animator;
    public float currentHealth {get; private set;}
    private bool dead;

    private void Awake(){
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage){

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        Rigidbody2D playerRb = GetComponent<Rigidbody2D>();
        if (currentHealth > 0){

            animator.SetBool("grounded", true);
            animator.SetTrigger("Hurt");
            playerRb.velocity = new Vector3(0,0,0);
            //iframes
        } else {
            if(!dead){
                
                animator.SetBool("grounded", true);
                animator.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                playerRb.velocity = Vector3.zero;
                dead = true;
            }
            
        }


    }
    
}
