using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float startingHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private bool canRevive;
    [SerializeField] private bool canEnrage;
    [SerializeField] private float reviveDelay;
    public bool isInvulnerable;
    public float currentHealth {get; private set;}
    private bool dead;

    [Header ("IFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float numberOfFlashes;
    [SerializeField] private SpriteRenderer spriteRend;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    [SerializeField] UnityEvent activateRespawn;
    private void Awake(){
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage){
        if (isInvulnerable)
        {
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        Rigidbody2D playerRb = GetComponent<Rigidbody2D>();

        if (currentHealth > 0){
            animator.SetBool("grounded", true);
            animator.SetTrigger("Hurt");

            Debug.Log("Current health: " + currentHealth + "StartingHealth/2: " + startingHealth / 2);

            if (canEnrage && currentHealth <= startingHealth / 2)
            {
                animator.SetBool("isEnrage", true);
            }

            StartCoroutine(Invunerability());

            //iframes
        } else {
            if(!dead){
                Die();
                if (canRevive)
                {   
                    StartCoroutine(Revive(reviveDelay));
                }
            }
            
            
        }


    }

    private void Die()
    {
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }
        animator.SetTrigger("Die");
        dead = true;
    }

    private IEnumerator Revive(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        activateRespawn.Invoke();
        animator.SetTrigger("Revive");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
        dead = false;
        currentHealth = startingHealth;
    }

    private IEnumerator Invunerability()
    {
        Debug.Log("Start invunerability");
        Physics2D.IgnoreLayerCollision(7, 8, true);
        //main logic
        for (int i = 0; i < numberOfFlashes; i++)
        {
           
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
