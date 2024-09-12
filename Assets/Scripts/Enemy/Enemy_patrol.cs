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

    [Header("Idle animations parametres")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animation")]
    [SerializeField] private Animator animator;

    private void OnDisable(){
        animator.SetBool("isMoving", false);
    }

    private void Update(){
        if(movingLeft){
            if(enemy.position.x >= leftEdge.position.x) MoveInDirection(-1);
            else DirectionChange();
        } else {
            if(enemy.position.x <= rightEdge.position.x ) MoveInDirection(1);
            else DirectionChange();
        }
    }
    private void MoveInDirection(int _direction){
        idleTimer = 0;
        animator.SetBool("isMoving", true);
        enemy.localScale = new Vector3(_direction, enemy.localScale.y, enemy.localScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    private void DirectionChange(){
        animator.SetBool("isMoving", false);
        idleTimer+= Time.deltaTime;
        if(idleTimer > idleDuration) movingLeft = !movingLeft;
    }
}
