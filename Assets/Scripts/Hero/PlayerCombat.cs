using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCombat : MonoBehaviour
{


    [Header ("References")]
    public Animator animator;
    [SerializeField] private BoxCollider2D AttackboxCollider;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private SFX_Hero sfx_hero;
    private PauseMenu pauseMenu;

    private float cooldownTimer = Mathf.Infinity;

    [Header("Attack parameters")]
    public bool canAttack = false;
    private Health enemyHealth;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float colliderDistance;


    private void Start()
    {
        pauseMenu = gameManager.GetComponent<PauseMenu>();
    }
    void Update(){
        if (!pauseMenu.isPause)
        {
            cooldownTimer += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && cooldownTimer >= attackCooldown && canAttack)
            {
                cooldownTimer = 0;
                Attack();
            }
        }
    }

    void Attack(){
        animator.SetTrigger("Attack");
    }

    private bool EnemyInSight(){
        RaycastHit2D hit = Physics2D.BoxCast(AttackboxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(AttackboxCollider.bounds.size.x * range, AttackboxCollider.bounds.size.y, AttackboxCollider.bounds.size.z)
        ,0, Vector2.left, 0, enemyLayer);
        

        if(hit.collider != null){
            enemyHealth = hit.transform.GetComponent<Health>();
            sfx_hero.Hero_hit();
        }

        Debug.Log("Enemy in signt?: " + hit.collider != null);
        return hit.collider!=null;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(AttackboxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
         new Vector3(AttackboxCollider.bounds.size.x * range, AttackboxCollider.bounds.size.y, AttackboxCollider.bounds.size.z));
    }

    private void DamageEnemy(){
        EnemyInSight();
        if (enemyHealth != null && EnemyInSight())
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    public void AttackEnable()
    {
        canAttack = true;
    }
}
