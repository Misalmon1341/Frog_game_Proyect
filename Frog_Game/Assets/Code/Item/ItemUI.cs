using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public ItemData itemData;
    [SerializeField]private Image icon;
    [SerializeField]private TextMeshProUGUI itemName;
    
    [Button]
    public void SetData()
    {
        icon.sprite = itemData.Icon;
        itemName.text = itemData.ItemName;
    }
}
