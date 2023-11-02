using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpçoesSetting : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    
    [SerializeField]
    private AudioSource musicAudioSource;
    void Start()
    {   
        float SavedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 13.0f);// Load the saved volume settings
        musicSlider.value = SavedMusicVolume; //Set value slider to SavedMusicVolume
        SetMusicVolume(SavedMusicVolume); //Pass SavedMusicVolume value as default 
    }
    void Update()
    {
        // Update float value musicSlider every time update
        SetMusicVolume(musicSlider.value);
    }
    public void SetMusicVolume(float volume)
    {
        // Update the music audio source volume
        musicAudioSource.volume = volume;
        // Save the volume settings
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
