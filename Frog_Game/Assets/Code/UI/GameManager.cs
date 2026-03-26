using NaughtyAttributes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Button]
    public void ChangeText()
    {   
        PopupUI popupUI = UiManager.Instance.GetWindow(WindowsIds.PopUI) as PopupUI;
        Debug.Log("Try Change Text");
        if (popupUI == null) return;
        popupUI.AddText("Hola");
        
        popupUI.ButtonYes.onClick.AddListener(() => {ClickedButtonYes(); });
        popupUI.ButtonNo.onClick.AddListener(() => {ClickedButtonNo(); });
    }
    
    
    [Button]
    public void ShowPopup()
    {
        UiManager.Instance.ShowWindow(WindowsIds.PopUI);
        PopupUI popupUI = UiManager.Instance.GetWindow(WindowsIds.PopUI) as PopupUI;
        popupUI.ButtonYes.onClick.RemoveAllListeners();
    }

    [Button]
    public void ChangeEvent()
    {
        PopupUI popupUI = UiManager.Instance.GetWindow(WindowsIds.PopUI) as PopupUI;
        popupUI.ButtonYes.onClick.RemoveAllListeners();
        popupUI.ButtonNo.onClick.RemoveAllListeners();
        popupUI.ButtonYes.onClick.AddListener(() => {Debug.Log("Se cambio de suscripcion"); });
    }
        
    [Button]
    public void ClosePopup()
    {
        UiManager.Instance.CloseWindow(WindowsIds.PopUI);
    }

    public void ClickedButtonYes()
    {
        Debug.Log("Button Yes");
    }

    public void ClickedButtonNo()
    {
        Debug.Log("Button No");
    }
}
