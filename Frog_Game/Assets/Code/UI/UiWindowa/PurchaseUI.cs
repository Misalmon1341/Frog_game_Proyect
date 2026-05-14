using UnityEngine;
using UnityEngine.UI;

public class PurchaseUI : UIWindow
{
    public Button purchaseButton;
    public override void Show()
    {
        
        base.Show();
    }
    
    public override void Hide()
    {
        purchaseButton.onClick.RemoveAllListeners();
        base.Hide();
    }
}
