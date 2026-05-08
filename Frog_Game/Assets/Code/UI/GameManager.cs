using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePlayElements;
    public static GameManager Instance;
    private int totalHearts = 3;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
        gamePlayElements.SetActive(false);
    }

    
    #region MainMenu Fuctions

    public void OnPlayButtonClick()
    {
        MainMenuUI mainMenuUI = UiManager.Instance.GetWindow(WindowsIds.MainMenuUI) as MainMenuUI; 
        UiManager.Instance.ShowWindow(WindowsIds.GameplayUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        gamePlayElements.SetActive(true);
    }

    public void OnStoreButtonClick()
    {
        MainMenuUI mainMenuUI = UiManager.Instance.GetWindow(WindowsIds.MainMenuUI) as MainMenuUI; 
        UiManager.Instance.ShowWindow(WindowsIds.StoreUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        //mainMenuUI.StoreButton.onClick.RemoveAllListeners();
    }
    public void OnSettingsClick()
    {
        MainMenuUI mainMenuUI = UiManager.Instance.GetWindow(WindowsIds.MainMenuUI) as MainMenuUI; 
        UiManager.Instance.ShowWindow(WindowsIds.SettingsUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        //mainMenuUI.SettingsButton.onClick.RemoveAllListeners();
    }
    public void OnCreditsClick()
    {
        MainMenuUI mainMenuUI = UiManager.Instance.GetWindow(WindowsIds.MainMenuUI) as MainMenuUI; 
        UiManager.Instance.ShowWindow(WindowsIds.CreditsUI);
        UiManager.Instance.CloseWindow(WindowsIds.MainMenuUI);
        //mainMenuUI.CreditsButton.onClick.RemoveAllListeners();
    }

   

    #endregion
    #region Gameplay Fuctions

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        UiManager.Instance.CloseWindow(WindowsIds.GameplayUI);
        UiManager.Instance.ShowWindow(WindowsIds.PauseUI);
    }

    public void LostHearts()
    {   
        GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        totalHearts -= 1;
        if (totalHearts == 0)
        {
            Time.timeScale = 0;
            UiManager.Instance.CloseWindow(WindowsIds.GameplayUI);
            UiManager.Instance.ShowWindow(WindowsIds.GameOverUI);
            
        }
        gameplayUI.DissabledHeart(totalHearts);
    }

    public bool WinHearts()
    {
        GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        if (totalHearts == 3)
        {
            return false;
        }
        gameplayUI.ActiveHeart(totalHearts);
        totalHearts += 1;
        return true;
    }
    
    #endregion

    #region Pause Functions

    public void OnResumeButtonClick()
    {
        PauseUI pauseUI = UiManager.Instance.GetWindow(WindowsIds.PauseUI) as PauseUI;
        UiManager.Instance.CloseWindow(WindowsIds.PauseUI);
        UiManager.Instance.ShowWindow(WindowsIds.GameplayUI);
        Time.timeScale = 1;
    }

    public void OnExitButtonClick()
    {
        PauseUI pauseUI = UiManager.Instance.GetWindow(WindowsIds.PauseUI) as PauseUI;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    #endregion
    
    #region Store Fuctions
    public void OnBackStoreButtonClick()
    { 
        StoreUI storeUI = UiManager.Instance.GetWindow(WindowsIds.StoreUI) as StoreUI;
        UiManager.Instance.CloseWindow(WindowsIds.StoreUI);
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
    }
    public void OnCosmeticButtonClick()
    { 
        StoreUI storeUI = UiManager.Instance.GetWindow(WindowsIds.StoreUI) as StoreUI;
        storeUI.CosmeticButton.image.sprite = storeUI.ActiveButtonSprt;
        storeUI.InventoryButton.image.sprite = storeUI.DissabledButtonSprt;
        storeUI.CosmeticScrollGroup.gameObject.SetActive(true);
        storeUI.InventoryScrollGroup.DOScale(Vector3.zero, 0.1f).OnComplete(() =>
        {
            storeUI.CosmeticScrollGroup.DOScale(Vector3.one, 0.1f).OnComplete(() =>
            { 
              storeUI.InventoryScrollGroup.gameObject.SetActive(false);
            });
        });
    }
    
    public void OnInventoryButtonClick()
    { 
        StoreUI storeUI = UiManager.Instance.GetWindow(WindowsIds.StoreUI) as StoreUI;
        storeUI.InventoryButton.image.sprite = storeUI.ActiveButtonSprt;
        storeUI.CosmeticButton.image.sprite = storeUI.DissabledButtonSprt;
        storeUI.InventoryScrollGroup.gameObject.SetActive(true);
        storeUI.CosmeticScrollGroup.DOScale(Vector3.zero, 0.1f).OnComplete(() =>
        {
            storeUI.InventoryScrollGroup.DOScale(Vector3.one, 0.1f).OnComplete(() =>
            { 
                storeUI.CosmeticScrollGroup.gameObject.SetActive(false);
            });
        });
        
    }
    #endregion
    #region  Settings Fuctions

    public void OnBackSettindsButtonClick()
    { 
        SettingsUI settings = UiManager.Instance.GetWindow(WindowsIds.SettingsUI) as SettingsUI;
        UiManager.Instance.CloseWindow(WindowsIds.SettingsUI);
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
    }
    #endregion
    #region  Credits Fuctions

    public void OnBackButtonClick()
    { 
        CreditsUI creditsUi = UiManager.Instance.GetWindow(WindowsIds.CreditsUI) as CreditsUI;
        UiManager.Instance.CloseWindow(WindowsIds.CreditsUI);
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
    }
    #endregion
    #region PopUp Functions
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
     

    #endregion
   
}
