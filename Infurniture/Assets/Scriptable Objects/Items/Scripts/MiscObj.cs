using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Misc Object", menuName = "Inventory/Items/Misc")]
public class MiscObj : ItemObj
{
    public void Awake(){
        type = type.Misc;
    }
}
