using NaughtyAttributes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
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
