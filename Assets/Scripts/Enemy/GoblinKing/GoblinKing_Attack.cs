using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing_Attack : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator bossAnim;

    [Header("Attack parameters")]
    [SerializeField] int attackDamage = 1;
    [SerializeField] private BoxCollider2D attackCollider;

    [Header("Camera parameters")]
    [SerializeField] Animator camerAnim;

    [Header("Charged Attack parameters")]
    [SerializeField] int enragedAttackDamage = 2;
    [SerializeField] private BoxCollider2D chAttackCollider;

    [Header("Wave parameters")]
    [SerializeField] Transform wavePoint; //точка от которой будет идти волна
    [SerializeField] GameObject wave;


    public Vector3 attackOffset;
    public LayerMask attackMask;

    private Health playerHealth;

    //[SerializeField] Health playerHealth;

    public void Attack()
    {
        //position of attack collider
        Collider2D colInfo = Physics2D.OverlapBox(attackCollider.bounds.center, attackCollider.bounds.size, 0, attackMask);
        if (colInfo != null)
        {
            
            playerHealth = colInfo.GetComponentInParent<Health>();
            playerHealth.TakeDamage(attackDamage);

            WinAnim();
        }
    }

    public void EnrageAttack()
    {

        Collider2D colInfo = Physics2D.OverlapBox(chAttackCollider.bounds.center, chAttackCollider.bounds.size, 0, attackMask);
        if (colInfo != null)
        {

            playerHealth = colInfo.GetComponentInParent<Health>();
            playerHealth.TakeDamage(enragedAttackDamage);

            WinAnim();
        }
        
    }

    void OnDrawGizmosSelected()
    {
       
    }

    public void WaveAfterAttack()
    {
        //wave logic
        wave.transform.position = wavePoint.position;
        Debug.Log("Transform pos: " + Mathf.Sign(transform.position.x));
        wave.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));     
    }

    private void WinAnim()
    {
        if (playerHealth.currentHealth <= 0)
        {
            bossAnim.SetTrigger("Win");
        }
    }
}
