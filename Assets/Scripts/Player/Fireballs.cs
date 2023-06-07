using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballs : MonoBehaviour
{
    public Transform firePos;
    public GameObject fireball;
    [SerializeField] private float cooldown;
    private float timer;
    public bool canShoot;
    // Update is called once per frame
    private void Awake()
    {
        canShoot = PlayerPrefs.GetInt("canShoot", 0) == 1 ? true : false;  
    }
    void Update()
    {
        if(!canShoot)
        {
            return;
        }
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
