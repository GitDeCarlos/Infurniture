using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory/Items/Equipment")]
public class EquipmentObj : ItemObj
{

    public int defense;
    public int attack;

    void Awake(){
        type = type.Equipment;
    }
}
