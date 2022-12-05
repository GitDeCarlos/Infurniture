using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{

    public InventoryObj inv;

    public void OnTriggerEnter2D(Collider2D obj){
        if(obj.CompareTag("groundItem")){
            var item = obj.GetComponent<GroundItem>();
            Debug.Log(item.Item);
            if(item != null){
                inv.addItem(new Item(item.Item,item.Item.id),1);
                Destroy(obj.gameObject);
            }
        }
    }
    private void OnApplicationQuit()
    {
        inv.invList.Items = new InventoryItem[20];
    }
}
