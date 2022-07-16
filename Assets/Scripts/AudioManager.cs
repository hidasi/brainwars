using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
    public AudioSource mainMenuMusic, intromusic,levelmusic;
    public AudioSource[] sfx;
    // Start is called before the first frame update
    public void PlayMainMenuMusic()
    {
        levelmusic.Stop();
        intromusic.Stop();
        mainMenuMusic.Play();
    }
    public void PlayLevelMusic()
    {
        if (!levelmusic.isPlaying)
        {
            intromusic.Stop();
            levelmusic.Play();
            mainMenuMusic.Stop();
        }
        
    }
    public void introMusic()
    {
        intromusic.Play();
        mainMenuMusic.Stop();
        levelmusic.Stop();
    }
    public void PAUSEMUSIC()
    {
        intromusic.Stop();
        mainMenuMusic.Stop();
        levelmusic.Stop();
    }
    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
