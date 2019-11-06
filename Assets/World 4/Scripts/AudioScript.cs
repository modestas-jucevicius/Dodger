using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip MusicClip;

    public AudioSource MusicSource;

    private bool paused = false;

    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(5, 5, 100, 50), "Mute music"))
        {
            if (paused)
            {
                MusicSource.UnPause();
                paused = false;
            }
            else
            {
                MusicSource.Pause();
                paused = true;
            }
        }
    }
}