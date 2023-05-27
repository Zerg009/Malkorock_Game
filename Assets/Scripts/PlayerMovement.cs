using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Rigidbody2D body;
    private Animator anim;
    private bool isGrounded;
    public bool isBlocked;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isBlocked)
            return;
        
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
    private void Attack()
    {
        anim.SetTrigger("Attack");

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
}
