using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] private StudioEventEmitter buttonClickSound;
    [SerializeField] private StudioEventEmitter coinCollectSound;
    [SerializeField] private StudioEventEmitter menuMusic;
    [SerializeField] private StudioEventEmitter gameMusic;

    [Header("Snapshots")]
    [SerializeField] private StudioEventEmitter sfxOn;
    [SerializeField] private StudioEventEmitter sfxOff;
    [SerializeField] private StudioEventEmitter musicOn;
    [SerializeField] private StudioEventEmitter musicOff;

    [Header("Game Settings")]
    [SerializeField] private GameSettings gameSettings;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        menuMusic.Play();
    }

    public void OnButtonClick()
    {
        buttonClickSound.Play();
    }

    public void OnPlayButtonClick()
    {
        menuMusic.Stop();
        gameMusic.Play();
    }

    public void OnMenuButtonClick()
    {
        gameMusic.Stop();
        menuMusic.Play();
    }

    public void OnScore()
    {
        coinCollectSound.Play();
    }

    public void OnMusicSettingsChanged()
    {
        Invoke("SetMusicState", 0.5f);
    }

    public void OnSfxSettingsChanged()
    {
        Invoke("SetSfxState", 0.5f);
    }

    private void SetMusicState()
    {
        StartCoroutine(SetSoundState(gameSettings.musicOn, musicOn, musicOff));
    }

    private void SetSfxState()
    {
        StartCoroutine(SetSoundState(gameSettings.sfxOn, sfxOn, sfxOff));
    }

    private IEnumerator SetSoundState(bool soundSetting, StudioEventEmitter soundOn, StudioEventEmitter soundOff)
    {
        yield return new WaitForSeconds(0.01f);

        if (soundSetting)
        {
            soundOff.Stop();
            soundOn.Play();
        }
        else
        {
            soundOn.Stop();
            soundOff.Play();
        }
    }

}
