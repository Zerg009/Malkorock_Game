using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    private bool isLoaded = false;
    private void Update()
    {
        if(!isLoaded)
            if (Input.GetKeyUp(KeyCode.Escape))
                LoadMainMenuDialog();
        
    }
    public void LoadMainMenuDialog()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        isLoaded = true;
    }

    public void CloseMainMenuDialog()
    {
        isLoaded = false;
        SceneManager.UnloadSceneAsync(3);
    }
}
