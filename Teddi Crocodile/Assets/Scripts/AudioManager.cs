using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    [SerializeField] Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource , sfxSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnEnable()
    {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound != null)
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s != null)
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
