using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private float cooldownTimer = Mathf.Infinity;

    // References
    private Animator anim;
    private Health playerHealth;
    private void Awake()
    {
        anim = GetComponent<Animator>();        
    }


    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight())
        {
            if (cooldownTimer > attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }
     
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range,
            boxCollider.bounds.size.z * range),
            0, Vector2.left, 0, playerLayer
        ) ;

        if (hit.collider != null)
        {
            //Debug.Log(hit);
            playerHealth = hit.transform.GetComponent<Health>();

        }


        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * range,
            boxCollider.bounds.size.z * range));
    }
    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            //Debug.Log(playerHealth);
            playerHealth.TakeDamage(damage);
            Debug.Log("Player health " + playerHealth.health);
        }
    }
}
