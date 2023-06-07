using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectille : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;
    public GameObject impact;
    [SerializeField] private int damage;
    private PlayerMovement playerController;
    private bool isFacingRight = true;

  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // Assuming you have a reference to the player controller script
        playerController = FindObjectOfType<PlayerMovement>();

        if (playerController != null)
        {
            float direction = playerController.transform.localScale.x > 0 ? 1 : -1;

            rb.velocity = Vector2.right * direction * bulletSpeed;
            // Check the player's movement direction
            bool isPlayerMovingRight = direction > 0;

            // Flip the projectile if the player changes direction
            if (isPlayerMovingRight && !isFacingRight)
            {
                FlipProjectile();
            }
            else if (!isPlayerMovingRight && isFacingRight)
            {
                FlipProjectile();
            }
        }
    }
    private void FlipProjectile()
    {
        isFacingRight = !isFacingRight;

        Vector3 newScale = transform.localScale;
        Vector3 newScale2 = impact.transform.localScale;

        newScale.x *= -1;
        newScale2.x *= -1;

        transform.localScale = newScale;
        impact.transform.localScale = newScale2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Traps")
        {
            Instantiate(impact, transform.position, Quaternion.identity);

            if (collision.GetComponent<Health>() != null) 
                collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
