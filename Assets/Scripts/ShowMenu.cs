using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuController;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu != null && !menu.gameObject.activeSelf)
            {
                menu.gameObject.SetActive(true);
                gameObject.GetComponent<PlayerMovement>().isBlocked = true; ;
            }
            else if(menu != null && menu.gameObject.activeSelf && menuController.gameObject.activeSelf)
            {
                menu.gameObject.SetActive(false);
                gameObject.GetComponent<PlayerMovement>().isBlocked = false; ;
            }
        }
    }
}
