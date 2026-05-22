using System;
using DG.Tweening;
using Dino.Utility.Audio;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gamePlayElements;
    public static GameManager Instance;
    private int totalHearts = 3;
    private int totalCoins = 0;
    public float speedMultiplier;
    private float distanceCounter;

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
        distanceCounter = 0;
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
        gamePlayElements.SetActive(false);
        GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        gameplayUI.CoinValue.text = totalCoins.ToString();
        AudioManager.Instance.PlaySound("MainMenuThem");
        Debug.Log("Se esta reproduciendo");
    }

    private void Update()
    {
        distanceCounter += Time.deltaTime * 10f;
        GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        gameplayUI.DistanceValue.text = distanceCounter.ToString("f0");
    }


    #region MainMenu Fuctions

   
    public void StartRun()
    {
        // Reset player pos => Player manager
        // Reset coins => Currency manager
        // Reset lifes => PlayerManager
        // Reset enemies => Enemies Manager
        // Move background => Background
        gamePlayElements.SetActive(true);
    }
    #endregion
    #region Gameplay Fuctions
    

    public void LostHearts()
    {   
        GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        totalHearts -= 1;
        if (totalHearts == 0)
        {
            AudioManager.Instance.PlaySound("deathsound");
            Time.timeScale = 0;
            UiManager.Instance.CloseWindow(WindowsIds.GameplayUI);
            UiManager.Instance.ShowWindow(WindowsIds.GameOverUI);
            AudioManager.Instance.StopSound("GamePlayThem");
            AudioManager.Instance.PlaySound("MainMenuThem");
            GameOverUi gameOverUI = UiManager.Instance.GetWindow(WindowsIds.GameOverUI) as GameOverUi;
            gameOverUI.CoinFinalValue.text = totalCoins.ToString();
            gameOverUI.DistanceFinalValue.text = distanceCounter.ToString("f0");
            
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
        AudioManager.Instance.PlaySound("hearthsound");
        gameplayUI.ActiveHeart(totalHearts);
        totalHearts += 1;
        return true;
    }

    public void AddCoins(int coins)
    {
        GamePlayUi gameplayUI = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        totalCoins += coins;
        gameplayUI.CoinValue.text = totalCoins.ToString();
    }
    
    #endregion
    /*
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
    */
    
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
