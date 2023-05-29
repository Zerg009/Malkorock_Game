using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolFly : MonoBehaviour
{
    [Header("Patrol Points")]
  

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    private bool isMovingLeft;
    private Vector3 initScale;
    private float leftEdge;
    private float rightEdge;

    public float minYOffset = -0.4f;      // Minimum Y offset from the initial position
    public float maxYOffset = 0.4f;       // Maximum Y offset from the initial position
    public float frequency = 0.5f;        // Frequency of the up and down movement

    private float initialY;             // Initial Y position


    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        initialY = transform.position.y;
    }
    private void Update()
    {
        if (isMovingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                MoveInDirection(-1);
            }
            else
                isMovingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                MoveInDirection(1);
            }
            else
                isMovingLeft = true;
        }
    }
   
    private void MoveInDirection(int _direction)
    {
        // Seed the random number generator with the current time
        Random.InitState(System.DateTime.Now.Millisecond);

        // Calculate the new Y position based on the bat's initial position and sinusoidal motion
        float newY = initialY + Mathf.Sin(Time.time * frequency) * (maxYOffset - minYOffset);


        //anim.SetBool("isRunning", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

              
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            Mathf.Lerp(transform.position.y, newY, speed * Time.deltaTime), enemy.position.z);
    }
    private void OnDisable()
    {
        //anim.SetBool("isRunning", false);
    }
}
