using System.Collections.Generic;
using Dino.Utility.Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUi : UIWindow
{
     [SerializeField] private Button pauseButton;
     [SerializeField] private GameObject[] hearts;
     [SerializeField] private TextMeshProUGUI coinValue;
     public Button PauseButton => pauseButton;
     public GameObject[] Hearts => hearts;
     public TextMeshProUGUI CoinValue => coinValue;
        public override void Show()
        {
            pauseButton.onClick.AddListener(() =>{OnPauseButtonClick();});
            base.Show();
        }
    

        public void DissabledHeart(int index)
        {
           hearts[index].SetActive(false);
        }

        public void ActiveHeart(int index)
        {
            hearts[index].SetActive(true);
        }
       
        public override void Hide()
        {
            pauseButton.onClick.RemoveAllListeners();
            base.Hide();
        }
        public void OnPauseButtonClick()
        {
            AudioManager.Instance.PlaySound("uiclickneutral");
            Time.timeScale = 0;
            GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
            UiManager.Instance.CloseWindow(WindowsIds.GameplayUI);
            UiManager.Instance.ShowWindow(WindowsIds.PauseUI);
        }
}
