using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Private Fields

    private List<AudioSource> systemSourceChannels;
    private List<AudioSource> activeSources;
    
    #endregion
    
    #region Singleton
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            systemSourceChannels = new List<AudioSource>();
            activeSources = new List<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    
    #region Play 2D Sounds

    public void PlayMusic(AudioClip clip)
    {
        if (systemSourceChannels.Count == 0)
        {
            systemSourceChannels.Add(gameObject.AddComponent<AudioSource>());
        }
        systemSourceChannels[0].Stop();
        systemSourceChannels[0].clip = clip;
        systemSourceChannels[0].Play();
    }

    public void StopMusic()
    {
        if (systemSourceChannels.Count > 0)
        {
            systemSourceChannels[0].Stop();
        }
    }

    public void PauseMusic()
    {
        if (systemSourceChannels.Count > 0)
        {
            systemSourceChannels[0].Pause();
        }
    }
    
    public void ResumeMusic()
    {
        if (systemSourceChannels.Count > 0)
        {
            systemSourceChannels[0].UnPause();
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (systemSourceChannels.Count == 0)
        {
            systemSourceChannels.Add(gameObject.AddComponent<AudioSource>());
        }
        systemSourceChannels[0].PlayOneShot(clip);
    }
    
    public void PlayAmbient(AudioClip clip)
    {
        while (systemSourceChannels.Count < 2)
        {
            systemSourceChannels.Add(gameObject.AddComponent<AudioSource>());
        }
        systemSourceChannels[1].Stop();
        systemSourceChannels[1].clip = clip;
        systemSourceChannels[1].Play();
    }

    public void StopAmbient()
    {
        if (systemSourceChannels.Count >= 2)
        {
            systemSourceChannels[1].Stop();
        }
    }

    public void PauseAmbient()
    {
        if (systemSourceChannels.Count >= 2)
        {
            systemSourceChannels[1].Pause();
        }
    }
    
    public void ResumeAmbient()
    {
        if (systemSourceChannels.Count >= 2)
        {
            systemSourceChannels[1].UnPause();
        }
    }
    #endregion
    
    
}
