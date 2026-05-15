using System;
using System.Collections;
using DG.Tweening;
using Dino.Utility.Audio;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public static StoreManager Instance { get;  private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public void OnBackStoreButtonClick()
    { 
        AudioManager.Instance.PlaySound("uiclickneutral");
        StoreUI storeUI = UiManager.Instance.GetWindow(WindowsIds.StoreUI) as StoreUI;
        UiManager.Instance.CloseWindow(WindowsIds.StoreUI);
        UiManager.Instance.ShowWindow(WindowsIds.MainMenuUI);
    }
    public void OnCosmeticButtonClick()
    { 
        AudioManager.Instance.PlaySound("uiclickpositive");
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
        AudioManager.Instance.PlaySound("uiclickpositive");
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

    public void OnPurchaseButtonClick()
    {
        PurchaseUI purchaseUI = UiManager.Instance.GetWindow(WindowsIds.PurchaseUI) as PurchaseUI;
        
    }
    
    public void ShowPurchasePanel(Button purchaseButton )
    {
        PurchaseUI purchaseUI = UiManager.Instance.GetWindow(WindowsIds.PurchaseUI) as PurchaseUI;
        UiManager.Instance.ShowWindow(WindowsIds.PurchaseUI);
        StartCoroutine(ShowPurchasePanelCoroutine());
        purchaseButton.onClick.RemoveAllListeners();
    }

    public IEnumerator ShowPurchasePanelCoroutine()
    {
        yield return new WaitForSeconds(4f);
        UiManager.Instance.CloseWindow(WindowsIds.PurchaseUI);
    }
}
