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

    public void DestroyDiary()
    {
        Destroy(gameObject);
        playerMovement.isBlocked = false;
        confirmationWindow.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            confirmationWindow.SetActive(true);
            playerMovement.isBlocked = true;
            GameObject.Find("DialogManager").GetComponent<DialogManager>().isShowingDiaryWindow = true;
        }
    }
}
