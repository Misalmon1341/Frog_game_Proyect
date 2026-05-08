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
    }

    public void OnMusicValueChange(float value)
    {
        SettingsManager.Instance.SetMusicValue(value);   
    }
    

    public override void Show()
    {
        backSettingsButton.onClick.AddListener(() => {GameManager.Instance.OnBackSettindsButtonClick();});
        base.Show();
    }

    public override void Hide()
    {
        backSettingsButton.onClick.RemoveAllListeners();
        base.Hide();
    }
}
