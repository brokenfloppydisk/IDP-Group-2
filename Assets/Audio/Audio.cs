using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio : MonoBehaviour
{
    
    public AudioSource audioSource;

    public AudioClip clip;

    public float volume = 0.5f;

    public void playOneShot() {
        audioSource.PlayOneShot(clip, volume);
    }

    public void play() {
        audioSource.Play();
    }

}
