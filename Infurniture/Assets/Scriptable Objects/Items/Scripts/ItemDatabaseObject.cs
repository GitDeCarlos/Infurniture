using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObj[] Items;
    public Dictionary<ItemObj, int> GetId = new Dictionary<ItemObj, int>();
    public Dictionary<int, ItemObj> GetItem = new Dictionary<int, ItemObj>();
    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<ItemObj, int>();
        GetItem = new Dictionary<int, ItemObj>();
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].id = i;
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemObj>();
    }
}