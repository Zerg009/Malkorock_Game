using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryWindow : MonoBehaviour
{
    public GameObject confirmationWindow;
    public PlayerMovement playerMovement;
    
    private void Awake()
    {
        confirmationWindow.SetActive(false);

    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Destroy(gameObject);
            playerMovement.isBlocked = false;
            confirmationWindow.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Debug bblea");
        if (collision.gameObject.CompareTag("Player"))
        {
            confirmationWindow.SetActive(true);
            playerMovement.isBlocked = true;
        }
    }
}
