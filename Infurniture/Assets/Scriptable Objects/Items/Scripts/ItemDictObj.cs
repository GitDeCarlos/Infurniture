using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Dictionary", menuName = "Inventory/Item Dictionary")]
public class ItemDictObj : ScriptableObject
{
    public List<ItemObj> objList = new List<ItemObj>();
    public List<string> nameList = new List<string>();
    public List<GameObject> prefabs = new List<GameObject>();
}
