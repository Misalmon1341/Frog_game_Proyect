using UnityEngine;
using UnityEngine.UI;

public class StoreUI : UIWindow
{
    // cat 1
    // cat 2
    [SerializeField] private ItemData[] _itemData;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _itemContainer;
    [SerializeField] private Button backBtnStore;
    [SerializeField] private Button cosmeticButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private Sprite activeBttnSprt;
    [SerializeField] private Sprite dissabledBttnSprt;
    [SerializeField] private RectTransform cosmeticScrollGroup;
    [SerializeField] private RectTransform inventoryScrollGroup;
    public Sprite ActiveButtonSprt => activeBttnSprt;
    public Sprite DissabledButtonSprt => dissabledBttnSprt;
    public Button InventoryButton => inventoryButton;
    public Button CosmeticButton => cosmeticButton;
    public RectTransform CosmeticScrollGroup => cosmeticScrollGroup;
    public RectTransform InventoryScrollGroup => inventoryScrollGroup;
    public void SpawnItem()
    {
        foreach (var itemData in _itemData)
        {
            GameObject itemGo = Instantiate(_itemPrefab, _itemContainer); 
            itemGo.GetComponent<ItemUI>().SetItemData(itemData);
        }
        
    }

    public override void Initialize()
    {
        cosmeticScrollGroup.gameObject.SetActive(false);
        inventoryScrollGroup.gameObject.SetActive(true);
        base.Initialize();
        SpawnItem();
    }
      public override void Show()
        {
            backBtnStore.onClick.AddListener(() => { GameManager.Instance.OnBackStoreButtonClick();});
            cosmeticButton.onClick.AddListener(() => { GameManager.Instance.OnCosmeticButtonClick();});
            inventoryButton.onClick.AddListener(() => { GameManager.Instance.OnInventoryButtonClick();});
            base.Show();
        }
    
        public override void Hide()
        {
            backBtnStore.onClick.RemoveAllListeners();
            cosmeticButton.onClick.RemoveAllListeners();
            inventoryButton.onClick.RemoveAllListeners();
            base.Hide();
        }
}
