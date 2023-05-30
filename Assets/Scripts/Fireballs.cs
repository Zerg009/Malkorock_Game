using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    public Transform firePos;
    public GameObject fireball;
    [SerializeField] private float cooldown;
    private float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetMouseButtonDown(1))
        {
            if(timer > cooldown)
            {
                Instantiate(fireball, firePos.position, firePos.rotation);
                timer = 0;
            }
        }
    }
}
