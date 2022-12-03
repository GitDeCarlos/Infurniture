using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public InventoryObj chestInv;

    public void openChest(){
        //INSERT CODE TO OPEN CHEST UI
    }

    public void insertIntoChest(ItemObj item, int quantity){
        chestInv.addItem(item, quantity);
    }

    public void DoInteraction(){
        openChest();
    }
}
