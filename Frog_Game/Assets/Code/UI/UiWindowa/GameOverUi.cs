using Dino.Utility.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUi : UIWindow
{
      [SerializeField] private Button retryButton;
      [SerializeField] private Button exitButton;
      [SerializeField] private TextMeshProUGUI coinFinalValue;
      
      public TextMeshProUGUI CoinFinalValue => coinFinalValue;
      
      public override void Initialize()
      {
          base.Initialize();
      }
       public override void Show()
       {
           base.Show();
           retryButton.onClick.AddListener(() => {OnRetryButtonClick();});
           exitButton.onClick.AddListener(() => {OnExitGameOverButtonClickk();});
       }

    
   
       public override void Hide()
       {
           base.Hide();
           exitButton.onClick.RemoveAllListeners();
           retryButton.onClick.RemoveAllListeners();
       }
       public void OnExitGameOverButtonClickk()
       {
           AudioManager.Instance.PlaySound("uiclicknegative");
           Time.timeScale = 1;
           SceneManager.LoadScene(0);
       }
       public void OnRetryButtonClick()
       {
           AudioManager.Instance.PlaySound("uiclickpositive");
           SceneManager.LoadScene(0);
           Time.timeScale = 1;
           MainMenuUI mainMenuUI = UiManager.Instance.GetWindow(WindowsIds.MainMenuUI) as MainMenuUI;
           mainMenuUI.HideOnStart = true;
           //UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
       }
}
