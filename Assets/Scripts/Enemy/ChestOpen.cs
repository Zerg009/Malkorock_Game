using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField] private EnemyPatrolFly[] enemies;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Canvas canvas;
    private Animator anim;
    private bool canOpen = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        canOpen = true;
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 10 )
        {
            foreach(EnemyPatrolFly enemy in enemies)
            {
                if (enemy.gameObject.activeSelf)
                {
                    canOpen = false;
                    Animator textAnimator = canvas.GetComponentInChildren<Animator>();
                    textAnimator.SetTrigger("Show");
                }
                break;
            }
            if(canOpen )
            {
                // do something
                Debug.Log("Opened chest");
                anim.SetTrigger("Open");
                
            }
        }
    }
}
