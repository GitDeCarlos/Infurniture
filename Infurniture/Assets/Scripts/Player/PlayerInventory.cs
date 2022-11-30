using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{

    public InventoryObj inv;

    public void OnTriggerEnter2D(Collider2D obj){
        if(!obj.CompareTag("interactableObject")){
            var item = obj.GetComponent<item>();
            Debug.Log(item.Item);
            if(item != null){
                inv.addItem(item.Item, 1);
                Destroy(obj.gameObject);
            }
        }
    }
}
