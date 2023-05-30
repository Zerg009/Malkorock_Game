using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySaw : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float pushDistance;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private float direction;

    [SerializeField] private float damageInterval;
    private float damageTimer;
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        
        
    }
    private void Update()
    {
        if (movingLeft)
        {
            if(transform.position.x > leftEdge) 
            { 
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,transform.position.y,
                    transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y,
                   transform.position.z);
            }
            else
                movingLeft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        damageTimer += Time.deltaTime;
        if(damageTimer > damageInterval)
        {
            Damage(collision);
            damageTimer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damage(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        damageTimer += Time.deltaTime;
        if (damageTimer > damageInterval)
        {
            Damage(collision);
            damageTimer = 0;
        }
    }
    private void Damage(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Transform playerTransform = collision.gameObject.transform;
            //direction = playerTransform.localScale.x > 0 ? -1:1;
            //Vector2 pushDirection = new Vector2(direction,0).normalized;
            //Debug.Log(direction);

            //Vector2 velocity = new Vector2(direction * pushDistance, 0); // Adjust the X component to control the backward velocity

            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;

            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 0), ForceMode2D.Impulse);
        }

    }
    private void Damage(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }

    }
}
