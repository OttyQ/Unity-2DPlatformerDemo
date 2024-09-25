using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_meele : MonoBehaviour
{
    [SerializeField] private float attackCooldown; 
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    

    [Header ("References")]
    private Health playerHealth;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private BoxCollider2D goblinBoxCollider;
    [SerializeField] private LayerMask playerLayer; 
    private float cooldownTimer = Mathf.Infinity;
    private RaycastHit2D hit;


    [Header ("Patrol Settings")]
    [SerializeField] private bool isPatrol;
    [SerializeField] private Enemy_patrol enemyPatrol;



    private void OnDisable(){
        goblinBoxCollider.enabled = false;
    }
    private void Update(){
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight()){
            if(cooldownTimer >= attackCooldown){
            cooldownTimer = 0;
            animator.SetTrigger("Attack");
            }
        }
        if (isPatrol)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        
        
    }

    private bool PlayerInSight(){
        hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
        ,0, Vector2.left, 0, playerLayer);
        

        if(hit.collider != null){
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider!=null;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
        Gizmos.color = Color.blue;
        if (isPatrol)
        {
            Gizmos.DrawWireSphere(boxCollider.bounds.center, enemyPatrol.chaseDistance);
        }
       
    }

    private void DamagePlayer(){
        if(PlayerInSight()){
            playerHealth.TakeDamage(damage);
        }
    }
}
