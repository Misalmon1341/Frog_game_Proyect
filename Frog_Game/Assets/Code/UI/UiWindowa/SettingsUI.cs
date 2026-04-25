using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : UIWindow
{
    [Header("SettingsUI")]
    [SerializeField] private Slider musicSlide;
    [SerializeField] private Slider sfxSlide;

    public override void Initialize()
    {
        base.Initialize();
        musicSlide.onValueChanged.AddListener(OnMusicValueChange);
        musicSlide.value = SettingsManager.Instance.MusicValue;
    }

    public void OnMusicValueChange(float value)
    {
        SettingsManager.Instance.SetMusicValue(value);   
    }
    

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
