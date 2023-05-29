using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth;
 
    public float health { get; private set; }
    private bool dead;
    private Animator anim;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private void Awake()
    {
        health = startingHealth;
        anim = GetComponent<Animator>();
    }
   
    public void TakeDamage(float _health)
    { 
        this.health = Mathf.Clamp(this.health - _health, 0, startingHealth );

        if (health > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            Debug.Log(dead);
            if(!dead)
            {
                anim.SetTrigger("Die");
            
                //// Player dead
                //if(GetComponent<PlayerMovement>() != null ) 
                //    GetComponent<PlayerMovement>().enabled = false;

                //// Enemy
                //if(GetComponentInParent<EnemyPatrol>() != null )
                //    GetComponentInParent<EnemyPatrol>().enabled = false;
                 
                //if (GetComponent<EnemyBaseClass>() != null)
                //{
                //    GetComponent<EnemyBaseClass>().enabled = false;
                //    //GetComponent<EnemyBaseClass>().gameObject.SetActive(false);
                //}
                    
                foreach(Behaviour behaviour in components)
                {
                    behaviour.enabled = false;
                }
                dead = true;
            }
        }
    }
    public void IncreaseHealth(float _health)
    {
        Debug.Log(health + " +  " + _health  + " = ");
        health = Mathf.Clamp(health + _health, 0, startingHealth);
        Debug.Log(health);
    }
}
