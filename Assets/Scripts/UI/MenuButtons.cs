using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
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
        // hide the MainMenuDialog canvas
        this.gameObject.SetActive(false);

        // allow player to move
        GameObject.Find("Player").GetComponent<PlayerMovement>().isBlocked = false;
    }
   
}
