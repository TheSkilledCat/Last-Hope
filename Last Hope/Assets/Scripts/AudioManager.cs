using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider volSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
            Load();
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volSlider.value;
        Save();
    }
    public void Load()
    {
        volSlider.value = PlayerPrefs.GetFloat("musicVOlume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volSlider.value);
    }
}

