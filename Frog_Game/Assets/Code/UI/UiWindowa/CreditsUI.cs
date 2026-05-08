using UnityEngine;
using UnityEngine.UI;

public class CreditsUI : UIWindow
{
    [SerializeField] private Button backButton;
    public Button BackButton => backButton;

    public override void Show()
    {
        backButton.onClick.AddListener(() =>{GameManager.Instance.OnBackButtonClick();});
        base.Show();
    }
    
    public override void Hide()
    {
        backButton.onClick.RemoveAllListeners();
        base.Hide();
    }
}
