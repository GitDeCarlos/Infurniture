using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem{
    public int ID =-1;
    public Item item;
    public int quantity;

    public InventoryItem()
    {
        ID = -1;
        item = null;
        quantity = 0;
    }
    public InventoryItem(Item _item, int _quantity, int _id){
        ID = _id;
        item = _item;
        quantity = _quantity;
    }
    
    public void UpdateSlot(Item item, int quantity, int _id)
    {
        this.ID = _id;
        this.item = item;
        this.quantity = quantity;
    }

    public void addItemQuantity(int v){
        quantity += v;
    }


}
[System.Serializable]
public class Inventory
{
    public InventoryItem[] Items = new InventoryItem[30];
}

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryObj : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemDatabaseObject database;
    public Inventory invList = new Inventory();
    public int currSelected = 0;

    public void addItem(Item item, int quantity) {
        //bool isPresent = false;
        if (item.type != type.Equipment) {
            for (int i = 0; i < invList.Items.Length; i++) {
                if (invList.Items[i].item.Name == item.Name) {
                    invList.Items[i].addItemQuantity(quantity);
                    return;
                }
            }
        }
        SetEmptySlot(item, quantity);
    }

    public void SetEmptySlot(Item item, int quantity)
    {
        for (int i = 0; i < invList.Items.Length; i++)
        {
            if (invList.Items[i].ID < 0)
            {
                invList.Items[i].UpdateSlot(item, quantity, item.Id);
                return;
                //return invList.Items[i];
            }
        }
        //return null;
    }
    

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < invList.Items.Length; i++)
        {
            if(invList.Items[i].ID < 0)
            invList.Items[i].item = new Item(database.GetItem[invList.Items[i].ID],invList.Items[i].item.Id);
        }
    }

    public void OnBeforeSerialize()
    {
        //throw new System.NotImplementedException();
    }

    public void removeItem(Item item){
        for (int i = 0; i < invList.Items.Length; i++)
        {
            if (invList.Items[i].item == item)
            {
                Debug.Log("Item Removed");
                invList.Items[i].UpdateSlot(null, 0, -1);
            }
        }
    }



    public void nextItem()
    {
        if(currSelected < 29)
        {
            Debug.Log("Next Item Seletced");
            currSelected += 1;
        }
    }

    public void prevItem()
    {
        if(currSelected > 0)
        {
            Debug.Log("Previous Items Selected");
            currSelected -= 1;
        }
    }


}
