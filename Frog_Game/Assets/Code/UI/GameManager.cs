using NaughtyAttributes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Button]
    public void ChangeText()
    {
        Debug.Log("Try Change Text");
        PopupUI popupUI = UiManager.Instance.GetWindow(WindowsIds.PopUI) as PopupUI;
        if (popupUI == null) return;
        Debug.Log("Text Changed");
        popupUI.AddText("Hola");
        
        popupUI.OnClicNo.AddListener(() => { Debug.Log("Clic No"); });
    }
    
    
    [Button]
    public void ShowPopup()
    {
        UiManager.Instance.ShowWindow(WindowsIds.PopUI);
        
    }

    [Button]
    public void ClosePopup()
    {
        UiManager.Instance.CloseWindow(WindowsIds.PopUI);
    }
}
