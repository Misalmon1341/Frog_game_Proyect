using Dino.Utility.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : UIWindow
{
    [SerializeField]private Button resumeButton;
    [SerializeField]private Button exitButton;
    [SerializeField]private Slider musicSlide;
    [SerializeField]private Slider sfxSlide;
    public Button ResumeButton => resumeButton;
    public Button ExitButton => exitButton;

    public override void Initialize()
    {
        base.Initialize();
        musicSlide.onValueChanged.AddListener(OnMusicValueChanged);
        musicSlide.value = SettingsManager.Instance.MusicValue;
        sfxSlide.onValueChanged.AddListener(OnSfxValueChanged);
        sfxSlide.value = SettingsManager.Instance.SfxValue;
    }
    public override void Show()
    {
        resumeButton.onClick.AddListener(() => {OnResumeButtonClick();});
        exitButton.onClick.AddListener(() => {OnExitButtonClick();});
        base.Show();
    }
    
    public override void Hide()
    {
        resumeButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        base.Hide();
    }
    public void OnResumeButtonClick()
    {
        AudioManager.Instance.PlaySound("uiclickpositive");
        UiManager.Instance.CloseWindow(WindowsIds.PauseUI);
        UiManager.Instance.ShowWindow(WindowsIds.GameplayUI);
        Time.timeScale = 1;
    }

    public void OnExitButtonClick()
    {
        AudioManager.Instance.PlaySound("uiclicknegative");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void OnSfxValueChanged(float value)
    {
        AudioManager.Instance.PlaySound("uiclickspecial");
        SettingsManager.Instance.SetSfxValue(value);
    }

    public void OnMusicValueChanged(float value)
    {
        AudioManager.Instance.PlaySound("uiclickspecial");
        SettingsManager.Instance.SetMusicValue(value);
    }

}
