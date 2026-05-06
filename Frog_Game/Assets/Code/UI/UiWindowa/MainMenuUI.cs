using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UIWindow
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button storeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    
    public Button PlayButton => playButton;
    public Button StoreButton => storeButton;
    public Button SettingsButton => settingsButton;
    public Button CreditsButton => creditsButton;
    public override void Initialize()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
        
    }

    public void OnPlayButtonClick()
    {
        
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
