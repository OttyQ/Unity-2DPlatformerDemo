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
    [SerializeField] Animator bossAnim;


    public Vector3 attackOffset;
    public LayerMask attackMask;

    private Health playerHealth;

    //[SerializeField] Health playerHealth;

    public void Attack()
    {
        
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            //colInfo.GetComponentInParent<Health>().TakeDamage(attackDamage);
            playerHealth = colInfo.GetComponentInParent<Health>();
            playerHealth.TakeDamage(attackDamage);
            if (playerHealth.currentHealth <= 0)
            {
                bossAnim.SetTrigger("Win");
            }
        }
        
    }

    public void Update()
    {
        
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

            playerHealth = colInfo.GetComponentInParent<Health>();
            playerHealth.TakeDamage(enragedAttackDamage);
            if(playerHealth.currentHealth <= 0)
            {
                bossAnim.SetTrigger("Win");
            }

            
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
