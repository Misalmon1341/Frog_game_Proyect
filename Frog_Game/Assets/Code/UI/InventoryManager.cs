using System;
using System.Collections.Generic;
using Dino.UtilityTools.Extensions.Json;
using NaughtyAttributes;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
 public static InventoryManager Instance{get; private set;}
 public List<RuntimeItem> _itemsList = new List<RuntimeItem>();
 public List<ItemData> itemDataList = new List<ItemData>() ;
 
 private void Awake()
 {
     if(Instance != null && Instance != this)
     {
         Destroy(gameObject);
         return;
     }
     Instance = this;
 }

 private void Start()
 {
     LoadInventory();
 }

 public void CreateItem(ItemType itemType)
 {
     foreach (var item in itemDataList)
     {
         if (item.ItemType == itemType)
         {
             RuntimeItem runtimeItem = new RuntimeItem(item.Icon, item.ItemName,item.ItemType);
             _itemsList.Add(runtimeItem);
         }  
     }
 }
 [Button]
 private void SavedInventoy()
 {
    string json = JsonHelper.ToJson(_itemsList.ToArray(), prettyPrint: true);
    string path = Application.persistentDataPath + "/Inventory.json";
    System.IO.File.WriteAllText(path,json);
    
    Debug.Log("Inventory saved to:" + path);
    
    Debug.Log(json);
 }

 private void LoadInventory()
 {
     string path = Application.persistentDataPath + "/Inventory.json";
     if (!System.IO.File.Exists(path))
     {
         Debug.LogError("No inventory file found" + path);
         return;
     }

     string json = System.IO.File.ReadAllText(path);
     RuntimeItem[] loadedItems = JsonHelper.FromJson<RuntimeItem>(json);
     
     _itemsList.Clear();
     _itemsList.AddRange(loadedItems);
     
 }
 [Button]
public void CreateItemTest()
{
    CreateItem(ItemType.hat);
}
}

public enum ItemType
{
    hat,
    glasses,
    pendant
}
[Serializable]
public class RuntimeItem
{
    public Sprite Icon;
    public string ItemName;
    public ItemType ItemType;

    public RuntimeItem(Sprite icon, string itemName, ItemType type)
    {
        Icon = icon;
        ItemName = itemName;
        ItemType = type;
    }
}
