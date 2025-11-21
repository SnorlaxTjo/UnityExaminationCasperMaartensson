using System;
using UnityEngine;
using System.Collections.Generic;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private List<AudioSource> audioSources = new List<AudioSource>();

    private void Update()
    {
        foreach (AudioSource audio in audioSources)
        {
            if (!audio.isPlaying)
            {
                audioSources.Remove(audio);
                Destroy(audio.gameObject);
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        AudioSource sound = Instantiate(audioSource);
        sound.clip = clip;
        sound.Play();
        audioSources.Add(sound);
    }
}
