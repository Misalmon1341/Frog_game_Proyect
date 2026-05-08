using UnityEngine;
using UnityEngine.UI;

public class PauseUI : UIWindow
{
    [SerializeField]private Button resumeButton;
    [SerializeField]private Button exitButton;
    
    public Button ResumeButton => resumeButton;
    public Button ExitButton => exitButton;
    public override void Show()
    {
        resumeButton.onClick.AddListener(() => {GameManager.Instance.OnResumeButtonClick();});
        exitButton.onClick.AddListener(() => {GameManager.Instance.OnExitButtonClick();});
        base.Show();
    }
    
    public override void Hide()
    {
        resumeButton.onClick.RemoveAllListeners();
        exitButton.onClick.RemoveAllListeners();
        base.Hide();
    }
}
