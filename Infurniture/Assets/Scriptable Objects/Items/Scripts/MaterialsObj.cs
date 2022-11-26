using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Materials Object", menuName = "Inventory/Items/Materials")]
public class MaterialsObj : ItemObj
{


    void Awake(){
        type = type.Materials;
    }
}
