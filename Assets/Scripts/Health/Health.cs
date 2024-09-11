using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{   
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] private Animator animator;
    public float currentHealth {get; private set;}
    private bool dead;

    [Header ("IFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float numberOfFlashes;
    [SerializeField] private SpriteRenderer spriteRend;

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
            StartCoroutine(Invunerability());

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

    private IEnumerator Invunerability(){
        Debug.Log("Start invunerability");
        Physics2D.IgnoreLayerCollision(7,8,true);
        //main logic
        for(int i =0; i< numberOfFlashes; i++){
            Debug.Log("Start invunerability");
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration/ (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7,8,false);
    }
    
}
