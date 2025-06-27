using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    [Header("Audio Manager Components")] 
    [SerializeField] private AudioMixer gameMixer;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;
    
    [Header("Other Settings")]
    [SerializeField] private GameObject resolutionDropdown;
    [SerializeField] private Slider sensSlider;

    
    public static float musicVolume = 1;
    public static float sFXVolume = 1;

    private void Start()
    {
        resolutionDropdown.GetComponent<Dropdown>();
        musicVolumeSlider.value = musicVolume;
        SFXVolumeSlider.value = sFXVolume;
    }

    public void SetMusicVolume()
    {
        musicVolume = musicVolumeSlider.value;
        gameMixer.SetFloat("musicVolume", Mathf.Log10(musicVolume) * 20); 
    }
    
    public void SetSFXVolume()
    {
        sFXVolume = SFXVolumeSlider.value;
        gameMixer.SetFloat("sfxVolume", Mathf.Log10(sFXVolume) * 20); 
    }

    public void SetResolution(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
