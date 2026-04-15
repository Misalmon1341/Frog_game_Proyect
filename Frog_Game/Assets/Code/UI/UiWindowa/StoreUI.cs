using UnityEngine;

public class StoreUI : UIWindow
{
    // cat 1
    // cat 2
    [SerializeField] private ItemData[] _itemData;

    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _itemContainer;
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
        SpawnItem();
    }
      public override void Show()
        {
            base.Show();
        }
    
        public override void Hide()
        {
            base.Hide();
        }
}
