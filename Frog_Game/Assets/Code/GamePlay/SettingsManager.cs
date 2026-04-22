using System;
using NaughtyAttributes;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance { get; private set;}
    
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
    }

    public void SetMusicValue(float value)
    {
        musicValue = value;
    }
}
