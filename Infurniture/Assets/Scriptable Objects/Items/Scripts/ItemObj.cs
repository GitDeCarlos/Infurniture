using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemObj : ScriptableObject
{
    public GameObject inventorySlotPrefab;
    public GameObject prefab;
    [TextArea(10,20)]
    public string description;
    public string DisplayName;
    public type type;
}

public enum type{
    Equipment,
    Consumables,
    Materials,
    Misc
}
