using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private bool isMovingLeft;
    private Vector3 initScale;

    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void Update()
    {
        if(isMovingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1); 

            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {

                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }
    private void DirectionChange()
    {
        anim.SetBool("isRunning", false);
        idleTimer += Time.deltaTime;
        if(idleTimer > idleDuration)
            isMovingLeft = !isMovingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("isRunning", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
            initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
    private void OnDisable()
    {
        anim.SetBool("isRunning", false); 
    }
}
