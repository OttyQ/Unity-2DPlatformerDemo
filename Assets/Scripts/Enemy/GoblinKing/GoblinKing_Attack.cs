using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing_Attack : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [Header("Attack parameters")]
    [SerializeField] int attackDamage = 1;
    [SerializeField] int enragedAttackDamage = 2;
    [SerializeField] float attackRange;
    [SerializeField] Animator camerAnim;
   

    public Vector3 attackOffset;
    public LayerMask attackMask;

    [Header("References")]
    [SerializeField] Health playerHealth;

    public void Attack()
    {
        
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponentInParent<Health>().TakeDamage(attackDamage);
            //camerAnim.SetTrigger("Shake");
            //playerHealth.TakeDamage(attackDamage); 
        }
        
    }

    public void EnrageAttack()
    {
        
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;
        camerAnim.SetTrigger("Shake");

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            
            colInfo.GetComponentInParent<Health>().TakeDamage(enragedAttackDamage);
            
        }
        
    }



    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
