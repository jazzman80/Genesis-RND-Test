using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]

public class GameSettings : ScriptableObject
{

    public bool musicOn = true;
    public bool sfxOn = true;

    public void MusicSettingsChanged(bool musicSettings)
    {
        musicOn = musicSettings;
    }

    public void SfxSettingsChanged(bool sfxSettings)
    {
        sfxOn = sfxSettings;
    }

}
