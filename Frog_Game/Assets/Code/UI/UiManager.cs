using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }
    [SerializeField] private List<UIWindow> windows = new List<UIWindow>(); 
    void Start()
    {
        Initialize();
    }

    private void Awake()
    {
        //Si ya existe la instancia y no es esta, destruir este objeto para mantener el singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        //Asignar esta instancia unica de UIManager
        Instance = this;
    }
    private void Initialize()
    {
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
        UIWindow windowToShow = null;
        foreach (UIWindow window in windows)
        {
            if (window.WindowId == windowId)
            {
                windowToShow = window;
                break;
            }
        }

        if (windowToShow != null)
        {
            windowToShow.Show();
        }
        else
        {
            Debug.LogError($"No se encontro la ventana con ID {windowId}");
        }
        
        //if (windowToShow != null))
    }
    
    public void CloseWindow(string windowId)
    {
        UIWindow windowToClose = null;
        foreach (UIWindow window in windows)
        {
            if (window.WindowId == windowId)
            {
                windowToClose = window;
            }
        }

        if (windowToClose != null)
        {
            windowToClose.Hide();
        }
        else
        {
            Debug.Log($"No se encontro la ventana con ID");
        }
    }

    public UIWindow GetWindow(string windowId)
    {
        foreach (UIWindow window in windows)
        {
            if (window.WindowId == windowId)
            {
                Debug.Log("Found Window");
                return window;
            }
        }
        Debug.LogError($"No se encontro la ventana con ID");
        return null;
        
    }

 
    void Update()
    {
        
    }
}

public static class WindowsIds
{
    public const string PopUI = "popupui";
    public const string SettingsUI = "settingsui";
    public const string StoreUI =  "storeui";
    public const string MainMenuUI =  "mainmenuui";
    public const string PurchaseUI =  "purchaseui";
    public const string CreditsUI =  "creditsui";
    public const string GameOverUI =  "gameoverui";
    public const string TutorialUI =  "tutorialui";
    public const string PauseUI =  "pauseui";
    public const string GameplayUI =  "gameplayui";
    
}