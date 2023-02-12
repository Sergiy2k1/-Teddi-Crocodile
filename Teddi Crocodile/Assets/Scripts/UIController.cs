using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private  Slider _musicSlider, _sfxSlider;
    [SerializeField] private GameObject offMusic, offSound;

    private bool _isOffMusic;
    private bool _isOffSound;
    

    private void Awake()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
 


    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        _isOffMusic = !_isOffMusic;

        if(_isOffMusic)
        {
            offMusic.SetActive(true);
        }
        else 
        {
            offMusic.SetActive(false); 
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        _isOffSound = !_isOffSound;

        if(_isOffSound)
        {
            offSound.SetActive(true);
        }
        else
        {
            offSound.SetActive(false);
        }
    }


    public void MusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", _musicSlider.value);
    }

    public void SFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", _sfxSlider.value);
    }



    public void SaveMusicVolume()
    {
        AudioManager.Instance.MusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
    }


    public void SaveSFXVolume()
    {
        AudioManager.Instance.SFXVolume(PlayerPrefs.GetFloat("SFXVolume"));
    }
}
  