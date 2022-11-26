using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory/Items/Consumbale")]
public class ConsumableObj : ItemObj
{
    public int healthChange;

    void Awake(){
        type = type.Consumables;
    }
}
