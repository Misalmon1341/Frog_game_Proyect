using UnityEngine;
using UnityEngine.UI;

public class GameOverUi : UIWindow
{
      [SerializeField] private Button retryButton;
      [SerializeField] private Button exitButton;
      
      
       public override void Show()
       {
           base.Show();
           exitButton.onClick.AddListener(() => {GameManager.Instance.OnExitGameOverButtonClickk();});
       }
   
       public override void Hide()
       {
           base.Hide();
           exitButton.onClick.RemoveAllListeners();
       }
}
