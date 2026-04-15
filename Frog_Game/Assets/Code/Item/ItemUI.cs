using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField]private Image icon;
    [SerializeField]private TextMeshProUGUI itemName;
    
    [Button]
    public void SetItemData(ItemData itemData)
    {
        icon.sprite = itemData.Icon;
        itemName.text = itemData.ItemName;
    }
}
