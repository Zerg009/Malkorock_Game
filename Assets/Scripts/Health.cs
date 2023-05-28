using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
 
    public float health { get; private set; }
    private Animator anim;

    private void Awake()
    {
        health = startingHealth;
        anim = GetComponent<Animator>();
    }
   
    public void TakeDamage(float health)
    { 
        this.health = Mathf.Clamp(this.health - health, 0, startingHealth ); 

        if(health < 0 )
        {
            // Player dead
            anim.SetTrigger("Dead");

        }
    }
}
