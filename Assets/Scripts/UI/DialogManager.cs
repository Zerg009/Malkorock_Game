using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public bool isShowingMainMenu = false;
    public bool isShowingDiaryWindow = false;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private DiaryWindow diaryWindow;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject mainMenuContainer;
    private PlayerMovement player;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // check if mainMenu was found
            if (mainMenu == null)
            {
                Debug.LogWarning("Set the mainMenu object!");
                return;
            }

            // check if showing diaryWindow
            if (this.isShowingDiaryWindow)
            {
                diaryWindow.DestroyDiary();
                isShowingDiaryWindow = false;
                return;
            }

            // turn on/off the mainMenu
            if (!mainMenu.activeSelf)
            {
                // show main mainMenu
                this.isShowingMainMenu = true;
                mainMenu.SetActive(true);
                
                player.isBlocked = true;
            }
            else if (mainMenu.activeSelf )
            {
                if (optionsMenu == null) 
                    Debug.LogWarning("Options menu container not found");
                if(mainMenuContainer == null)
                    Debug.LogWarning("Main menu container not found");

                // check if Escape is used to change between MainMenu options
                if (optionsMenu.activeSelf)
                {
                    optionsMenu.SetActive(false);
                    mainMenuContainer.SetActive(true);
                    return;
                }

                // hide main mainMenu
                this.isShowingMainMenu = false;
                mainMenu.SetActive(false);

                player.isBlocked = false;
            }
        }
    }
}
