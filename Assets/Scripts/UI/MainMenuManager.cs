using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuContainer;
    [SerializeField] GameObject optionsMenu;
    private void Update()
    {
        // on pressing Escape key
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            // check if Options Menu is open
            if (optionsMenu.activeSelf)
            {
                optionsMenu.SetActive(false);
                mainMenuContainer.SetActive(true);
            }
        }
    }
}
