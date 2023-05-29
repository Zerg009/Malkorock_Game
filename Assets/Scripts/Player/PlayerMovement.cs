using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;
    public bool isBlocked;

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;

    [Header("Player Layer")]
    [SerializeField] private LayerMask enemyLayer;

    private float cooldownTimer = Mathf.Infinity;
    // References
    private Health enemyHealth;




    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isBlocked)
        {
            anim.SetBool("isRunning", false);
        }
        
        // check for jump
        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        // check for attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        Run();

        // Set animator parameters
        //if (horizontalInput > 0.01 || horizontalInput < -0.01f)
        //    anim.SetBool("isRunning", true);
        //else
        //    anim.SetBool("isRunning", false);
       
        anim.SetBool("isGrounded", isGrounded);
    }
    private void Attack()
    {
        cooldownTimer += Time.deltaTime;
        //if (EnemyInSight())
        //{
            //if (cooldownTimer > attackCooldown)
            //{
            //    cooldownTimer = 0;
                anim.SetTrigger("Attack");
            //}
        //}
        
    }
    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range,
            boxCollider.bounds.size.z * range),
            0, Vector2.left, 0, enemyLayer
        );

        if (hit.collider != null)
        {
            //Debug.Log(hit);
            enemyHealth = hit.transform.GetComponent<Health>();

        }


        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range,
            boxCollider.bounds.size.z * range));
    }
    private void DamageEnemy()
    {
        if (EnemyInSight())
        {
            //Debug.Log(playerHealth);
            enemyHealth.TakeDamage(damage);
            Debug.Log("Enemy health " + enemyHealth.health);
        }
    }
    private void Run()
    { 

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        body.velocity = new Vector2(horizontalInput* speed, body.velocity.y);
        // Flip player when moving left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one * 6;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1) * 6;
        }
        anim.SetBool("isRunning", horizontalInput != 0);
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        isGrounded = false;
        anim.SetTrigger("Jump");
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }



}
