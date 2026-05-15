using Dino.Utility.Audio;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : UIWindow
{
    [Header("SettingsUI")]
    [SerializeField] private Slider musicSlide;
    [SerializeField] private Slider sfxSlide;
    [SerializeField] private Button backSettingsButton;

    public override void Initialize()
    {
        base.Initialize();
        musicSlide.onValueChanged.AddListener(OnMusicValueChange);
        musicSlide.value = SettingsManager.Instance.MusicValue;
        sfxSlide.onValueChanged.AddListener(OnSfxValueChange);
        sfxSlide.value = SettingsManager.Instance.SfxValue;
    }

    public void OnSfxValueChange(float value)
    {
        AudioManager.Instance.PlaySound("uiclickspecial");
        SettingsManager.Instance.SetSfxValue(value);
    }
    public void OnMusicValueChange(float value)
    {
        AudioManager.Instance.PlaySound("uiclickspecial");
        SettingsManager.Instance.SetMusicValue(value);   
    }
    

    public override void Show()
    {
        backSettingsButton.onClick.AddListener(() => {OnBackSettindsButtonClick();});
        base.Show();
    }

    public override void Hide()
    {
        backSettingsButton.onClick.RemoveAllListeners();
        base.Hide();
    }
    public void OnBackSettindsButtonClick()
    { 
        AudioManager.Instance.PlaySound("uiclickneutral");
        UiManager.Instance.CloseWindow(WindowsIds.SettingsUI);
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
    }
}
