using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private List<UIWindow> windows = new List<UIWindow>(); 
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
    }
    
    

    [Button]
    public void ShowPopup()
    {
        ShowWindow("popupui");
    }

    private void FoundUIScene()
    {
        windows.Clear();
        var uiWindows = gameObject.GetComponentsInChildren<UIWindow>(true);
        foreach (var uiWindow in uiWindows)
        {
            if (!windows.Contains(uiWindow))
            {
                windows.Add(uiWindow);
            }
        }
    }

    public void ShowWindow(string windowId)
    {
        //var uiWindow = windows.Find(x => x.name == windowId);

        foreach (UIWindow window in windows)
        {
            if (window.WindowId == windowId)
            {
                window.Show();
                return;
            }
        }
        
        //if (windowToShow != null))
    }

 
    void Update()
    {
        
    }
}
