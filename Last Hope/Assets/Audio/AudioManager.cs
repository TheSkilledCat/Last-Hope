using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlidermusic;
    public AudioSource backGroundSounds;
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
    // Start is called before the first frame update
    public void setlevel(float slidervol)
    {

        AudioListener.volume = volumeSlidermusic.value;
        Save();
    }
    public void Load()
    {
        volumeSlidermusic.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlidermusic.value);
    }
}
