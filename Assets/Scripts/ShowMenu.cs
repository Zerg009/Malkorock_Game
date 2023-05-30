using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuController;
    [SerializeField] private GameObject diaryWindow;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu != null && !menu.gameObject.activeSelf)
            {
                
                GameObject debugObj = GameObject.Find("Debug");
                TextMeshProUGUI debug = debugObj.GetComponent<TextMeshProUGUI>();
                
                if(diaryWindow != null)
                {
                    debug.text = "nu e null";
                    if (!diaryWindow.gameObject.activeSelf)
                    {
                        menu.gameObject.SetActive(true);
                        gameObject.GetComponent<PlayerMovement>().isBlocked = true;
                    }
                }
                else
                {
                    debug.text = "e null";
                    Debug.Log("diary = " + diaryWindow);
                    menu.gameObject.SetActive(true);
                    gameObject.GetComponent<PlayerMovement>().isBlocked = true;
                }
            }
            else if(menu != null && menu.gameObject.activeSelf && menuController.gameObject.activeSelf )
            {
                menu.gameObject.SetActive(false);
                gameObject.GetComponent<PlayerMovement>().isBlocked = false; ;
            }
        }
    }
}
