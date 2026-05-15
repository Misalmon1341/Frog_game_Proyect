using Dino.Utility.Audio;
using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : UIWindow
{
    [SerializeField] private Button backButton;
    public Button BackButton => backButton;

    public override void Show()
    {
        backButton.onClick.AddListener(() =>{OnBackButtonClick();});
        base.Show();
    }
    
    public override void Hide()
    {
        backButton.onClick.RemoveAllListeners();
        base.Hide();
    }
    public void OnBackButtonClick()
    { 
        AudioManager.Instance.PlaySound("uiclickneutral");
        UiManager.Instance.CloseWindow(WindowsIds.CreditsUI);
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
    }
}
