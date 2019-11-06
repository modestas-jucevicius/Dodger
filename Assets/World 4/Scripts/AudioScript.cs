using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource _musicSource;
    private bool paused; 

    public void Start()
    {
        _musicSource = GetComponent<AudioSource>();
        paused = Convert.ToBoolean(PlayerPrefs.GetInt("Mute", 0));
        if (paused)
        {
            _musicSource.Pause();
        }

    }

    public void Pause()
    {
        if (paused)
        {
            _musicSource.UnPause();
            paused = false;
            PlayerPrefs.SetInt("Mute", 0);
        }
        else
        {
            _musicSource.Pause();
            paused = true;
            PlayerPrefs.SetInt("Mute", 1);
        }
    }
}