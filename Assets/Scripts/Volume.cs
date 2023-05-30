using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] GameObject bar;

    public float volumeIncrement = 0.1f;

    public void IncreaseVolume()
    {
        AudioListener.volume = Mathf.Clamp01(AudioListener.volume + volumeIncrement);
        Debug.Log(AudioListener.volume);
        setVolume();
    }

    public void DecreaseVolume()
    {
        AudioListener.volume = Mathf.Clamp01(AudioListener.volume - volumeIncrement);
        Debug.Log(AudioListener.volume);
        setVolume();
    }
    private void Awake()
    {
        setVolume();
    }
    void setVolume()
    {
        bar.GetComponent<Image>().fillAmount = AudioListener.volume;
    }
}
