using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObj : ScriptableObject
{
    public int id;
    public GameObject inventorySlotPrefab;
    public GameObject prefab;
    [TextArea(10,20)]
    public string description;
    public string DisplayName;
    public type type;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public type type;
    public GameObject inventorySlotPrefab;
    public Item(ItemObj item, int id)
    {
        Name = item.DisplayName;
        Id = item.id;
        type = item.type;
        inventorySlotPrefab = item.inventorySlotPrefab;
    }
}

public enum type{
    Equipment,
    Consumables,
    Materials,
    Misc
}
