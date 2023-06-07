using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuController;
    [SerializeField] private GameObject diaryWindow;
    private DialogManager dialogManager;
    private void Awake()
    {
        dialogManager = GameObject.Find("DialogManager").GetComponent<DialogManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // check if menu was set as reference
            if (menu == null)
            {
                Debug.LogWarning("Set the menu object!");
                return;
            }
            
            // turn on/off the menu
            if (!menu.gameObject.activeSelf)
            {

                if (diaryWindow == null || dialogManager.isShowingDiaryWindow)
                {
                    return;
                }

                // show main menu
                dialogManager.isShowingMainMenu = true;
                menu.gameObject.SetActive(true);
                gameObject.GetComponent<PlayerMovement>().isBlocked = true;
            }
            else if(menu.gameObject.activeSelf && menuController.gameObject.activeSelf )
            {

                menu.gameObject.SetActive(false);
                gameObject.GetComponent<PlayerMovement>().isBlocked = false; ;
            }
        }
    }
}
