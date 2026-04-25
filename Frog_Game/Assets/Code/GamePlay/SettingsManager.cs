using System;
using NaughtyAttributes;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set; }

    [ReadOnly, SerializeField] private float musicValue = 1f;
    [ReadOnly, SerializeField] private float sfxValue = 1f;
    public float MusicValue => musicValue;
    public float SfxValue => sfxValue;


    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        ReadSeetings();
    }


    public void ReadSeetings()
    {
        musicValue = PlayerPrefs.GetFloat(PlayerPreKeys.musicValue);
        Debug.Log($"Music volume loaded {musicValue}");
        sfxValue = PlayerPrefs.GetFloat(PlayerPreKeys.sfxValue);
        Debug.Log($"Music volume loaded {sfxValue}");
    }
    public void SetMusicValue(float value)
    {
        musicValue = value;
        PlayerPrefs.SetFloat(PlayerPreKeys.musicValue, musicValue);
        Debug.Log("Se gardo el volumen de la musica");
    }

    public void SetSfxValue(float value)
    {
        sfxValue = value;
        PlayerPrefs.SetFloat(PlayerPreKeys.sfxValue, sfxValue);
        Debug.Log("Se gardo el volumen de la musica");
    }

    public static class PlayerPreKeys
    {
        public static string musicValue = "musicvalue";
        public static string sfxValue = "sfxValue";
    }
}
