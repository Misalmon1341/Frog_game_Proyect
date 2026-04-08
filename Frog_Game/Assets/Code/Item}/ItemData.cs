using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private string itemName;
    
    public Sprite Icon => icon;
    public string ItemName => itemName;
}
