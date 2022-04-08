using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField]
    private Slider volumeSlider;

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))//loads the saved music volume, however this only actually loads when the slider is active
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    public void ChangeVolume()//changes the volume of the slider
    {
        AudioListener.volume = volumeSlider.value;
        Save();//save the value when set
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
