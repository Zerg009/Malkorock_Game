using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    [SerializeField] Sprite btnSpriteDefault;
    [SerializeField] Sprite btnSpritePressed;
    [SerializeField] public GameObject showDialog;
    Image btnImage;

    private void Awake()
    {
        btnImage = GetComponent<Image>();
    }
    public void OnlyChangeImage()
    {
        if (btnImage.sprite == btnSpriteDefault)
        {
            btnImage.sprite = btnSpritePressed;
        }
        else
        {
            btnImage.sprite = btnSpriteDefault;
        }
    }
        public void changeImage()
        {
            if(btnImage.sprite == btnSpriteDefault)
            {
                btnImage.sprite = btnSpritePressed;
            }
            else
            {
                btnImage.sprite = btnSpriteDefault;
            }

            //if(showDialog != null) { 
        
            //    showDialog.SetActive(false);
            //}

            this.transform.parent.transform.parent.gameObject.SetActive(false);

            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
}
