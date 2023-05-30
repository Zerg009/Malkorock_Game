using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class OpenOptions : MonoBehaviour
{
    [SerializeField] public Volume volumeMenu;
    [SerializeField] public MainMenu mainMenu;
    public void LoadOptions()
    {
        if (mainMenu != null)
        {
            mainMenu.gameObject.SetActive(false);
        }
       // GameObject.Find("MainMenuContainer").SetActive(false);
        if (volumeMenu != null)
        {
            volumeMenu.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if (mainMenu != null)
            {
                mainMenu.gameObject.SetActive(true);
            }
            if (volumeMenu != null)
            {
                volumeMenu.gameObject.SetActive(false);
            }
        }
    }
    public void Resume()
    {
        gameObject.SetActive(false);
    }
}
