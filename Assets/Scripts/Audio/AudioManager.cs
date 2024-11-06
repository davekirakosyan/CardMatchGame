using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips; 

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
}
