using UnityEngine;
using UnityEngine.UI;

public class GamePlayUi : UIWindow
{
     [SerializeField] private Button pauseButton;
     public Button PauseButton => pauseButton;
        public override void Show()
        {
            pauseButton.onClick.AddListener(() =>{GameManager.Instance.OnPauseButtonClick();});
            base.Show();
        }
       
        public override void Hide()
        {
            pauseButton.onClick.RemoveAllListeners();
            base.Hide();
        }
}
