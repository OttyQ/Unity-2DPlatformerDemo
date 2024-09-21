using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_patrol : MonoBehaviour
{
    [Header("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    
    private bool movingLeft;
    private Vector3 targetPosition;

    [Header("Idle animations parametres")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animation")]
    [SerializeField] private Animator animator;

    [Header("Chasing parameters")]
    [SerializeField] private float chaseSpeed;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    private void OnDisable()
    {
        animator.SetBool("isMoving", false);
    }
    private void Awake()
    {
        targetPosition = rightEdge.position;
    }

    private void Update()
    {
        if (Vector2.Distance(enemy.position, playerTransform.position) < chaseDistance)
        {
            isChasing = true;
        }

        else isChasing = false;

        if (isChasing)
        {
            animator.SetBool("isMoving", true);
            if (enemy.position.x > playerTransform.position.x)
            {
                enemy.localScale = new Vector3(-1, enemy.localScale.y, enemy.localScale.z);
                enemy.position += Vector3.left * chaseSpeed * Time.deltaTime;
            }
            if (enemy.position.x < playerTransform.position.x)
            {
                enemy.localScale = new Vector3(1, enemy.localScale.y, enemy.localScale.z);
                enemy.position += Vector3.right * chaseSpeed * Time.deltaTime;
            }
        }
        else
        {
            
            if (movingLeft)
            {
                if (/*enemy.transform.position.x >= leftEdge.transform.position.x ||*/ enemy.transform.position.x >= targetPosition.x) MoveInDirection(-1);
                else DirectionChange();
            }
            else
            {
                if (/*enemy.transform.position.x <= rightEdge.transform.position.x || */enemy.transform.position.x <= targetPosition.x) MoveInDirection(1);
                else DirectionChange();
            }
        }
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        animator.SetBool("isMoving", true);
        enemy.localScale = new Vector3(_direction, enemy.localScale.y, enemy.localScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    private void DirectionChange()
    {
        
        animator.SetBool("isMoving", false);
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
            if (movingLeft) SetRandomRightPointPos();
            else SetRandomLeftPointPos();
        }
        
    }

    private void SetRandomLeftPointPos()
    {
        float randomX = Random.Range(rightEdge.position.x, enemy.position.x);
        targetPosition = new Vector3(randomX, enemy.position.y, enemy.position.z);
    }
    private void SetRandomRightPointPos()
    {
        float randomX = Random.Range(leftEdge.position.x, enemy.position.x);
        targetPosition = new Vector3(randomX, enemy.position.y, enemy.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(rightEdge.position, 0.2f);
        Gizmos.DrawWireSphere(leftEdge.position, 0.2f);
        Gizmos.DrawLine(leftEdge.transform.position, rightEdge.transform.position);
        Gizmos.DrawWireSphere(targetPosition, 0.1f);
    }
}