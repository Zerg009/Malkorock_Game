using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Transform spawnPoint;
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
            //Debug.Log(dead);
            if(!dead)
            {
                anim.SetTrigger("Die");
            
                    
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
    public void Resurrect()
    {
        foreach (Behaviour behaviour in components)
        {
            behaviour.enabled = true;
        }
        Debug.Log("ressurect");
        transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, transform.position.z);
        dead = false;
        health = startingHealth;
        anim.SetTrigger("Resurrect");
    }
}
