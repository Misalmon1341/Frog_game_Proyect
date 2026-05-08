using TMPro;
using UnityEngine;
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
           retryButton.onClick.AddListener(() => {GameManager.Instance.OnRetryButtonClick();});
           exitButton.onClick.AddListener(() => {GameManager.Instance.OnExitGameOverButtonClickk();});
       }
   
       public override void Hide()
       {
           base.Hide();
           exitButton.onClick.RemoveAllListeners();
           retryButton.onClick.RemoveAllListeners();
       }
}
