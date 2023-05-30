using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float wantedSize;
    private float CameraSize;
    private bool isEntered = false;
    private void Awake()
    {
        CameraSize = cam.orthographicSize;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("Player"))
        {
            if(!isEntered)
                cam.orthographicSize  = wantedSize;
            else
                cam.orthographicSize = CameraSize;
            changeEntered();
        }
    }
    private void changeEntered()
    {
        isEntered = !isEntered;
    }
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        cam.orthographicSize = CameraSize;
    //        changeEntered();
    //    }
    //}
}
