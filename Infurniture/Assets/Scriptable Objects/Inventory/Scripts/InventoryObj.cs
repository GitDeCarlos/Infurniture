using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem{
    public ItemObj item;
    public int quantity;

    public InventoryItem(ItemObj item, int quantity){
        this.item = item;
        this.quantity = quantity;
    }

    public void addItemQuantity(int v){
        quantity += v;
    }


}

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryObj : ScriptableObject
{
    public List<InventoryItem> invList = new List<InventoryItem>();

    public void addItem(ItemObj item, int quantity){
        bool isPresent = false;
        if(item.type != type.Equipment){
            for(int i = 0; i < invList.Count; i++){
                if(invList[i].item == item){
                    invList[i].addItemQuantity(quantity);
                    isPresent = true;
                    break;
                }
            }
        }
        if(!isPresent){
            invList.Add(new InventoryItem(item, quantity));
        }
    }
}
