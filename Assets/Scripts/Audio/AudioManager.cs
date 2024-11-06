using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public Slider volumeSlider;


    private void Awake()
    {
        volumeSlider.value=SaveSystem.GetSoundVolume();
    }

    public void PlayMatchedAudio()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    public void PlayRejectedAudio()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
        SaveSystem.SaveSettings(volumeSlider.value);
    }
}
