using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] OpenOptions mainMenu;
    public void Start_Game()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void CloseGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();


        #endif
    }
    public void Resume()
    {
        mainMenu.gameObject.SetActive(false);
    }
}
