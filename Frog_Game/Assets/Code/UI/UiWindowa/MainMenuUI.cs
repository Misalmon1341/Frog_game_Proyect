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
       base.Initialize();
    }

    
    public override void Show()
    {
        playButton.onClick.AddListener(() => {GameManager.Instance.OnPlayButtonClick();});
        storeButton.onClick.AddListener(() => {GameManager.Instance.OnStoreButtonClick();});
        settingsButton.onClick.AddListener(() => {GameManager.Instance.OnSettingsClick();});
        creditsButton.onClick.AddListener(() => {GameManager.Instance.OnCreditsClick();});
        base.Show();
    }

    public override void Hide()
    {
        playButton.onClick.RemoveAllListeners();
        storeButton.onClick.RemoveAllListeners();
        settingsButton.onClick.RemoveAllListeners();
        creditsButton.onClick.RemoveAllListeners();
        base.Hide();
    }
}
