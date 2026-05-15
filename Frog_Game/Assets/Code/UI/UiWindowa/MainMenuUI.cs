using Dino.Utility.Audio;
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
        playButton.onClick.AddListener(() => {OnPlayButtonClick();});
        storeButton.onClick.AddListener(() => {OnStoreButtonClick();});
        settingsButton.onClick.AddListener(() => {OnSettingsClick();});
        creditsButton.onClick.AddListener(() => {OnCreditsClick();});
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
    public void OnPlayButtonClick()
    {
        AudioManager.Instance.PlaySound("uiclickpositive");
        UiManager.Instance.ShowWindow(WindowsIds.GameplayUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        

        GameManager.Instance.StartRun();
        AudioManager.Instance.StopSound("MainMenuThem");
        AudioManager.Instance.PlaySound("GamePlayThem");
        
    }

    public void OnSettingsClick()
    {
        AudioManager.Instance.PlaySound("uiclickpositive");
        UiManager.Instance.ShowWindow(WindowsIds.SettingsUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        //mainMenuUI.SettingsButton.onClick.RemoveAllListeners();
    }
    public void OnCreditsClick()
    {
        AudioManager.Instance.PlaySound("uiclickpositive");
        UiManager.Instance.ShowWindow(WindowsIds.CreditsUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        //mainMenuUI.CreditsButton.onClick.RemoveAllListeners();
    }
    public void OnStoreButtonClick()
    {
        AudioManager.Instance.PlaySound("uiclickpositive");
        UiManager.Instance.ShowWindow(WindowsIds.StoreUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        //mainMenuUI.StoreButton.onClick.RemoveAllListeners();
    }
    

}
