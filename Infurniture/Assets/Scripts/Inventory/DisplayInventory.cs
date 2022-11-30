using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObj inventory;

    public int x_space;

    public int x_start;
    public int y_start;
    public int columns = 1;
    public int y_space;
   
    Dictionary<InventoryItem, GameObject> itemDisplayed = new Dictionary<InventoryItem, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InitDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay(); 
    }

    public void InitDisplay(){
        for (int i = 0; i < inventory.invList.Count; i++){
            var obj = Instantiate(inventory.invList[i].item.inventorySlotPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.transform.Find("ItemName (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = inventory.invList[i].item.DisplayName;
            obj.transform.Find("Quantity (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = inventory.invList[i].quantity.ToString();
            itemDisplayed.Add(inventory.invList[i],obj);
        }
    }

    public Vector3 GetPosition(int i){
        return new Vector3(x_start + (x_space * ( i % columns)), y_start + (-y_space * (i/columns)), 0f);
    }

    public void UpdateDisplay(){
        for (int i = 0; i < inventory.invList.Count; i++)
        {
            if(itemDisplayed.ContainsKey(inventory.invList[i])){
                itemDisplayed[inventory.invList[i]].transform.Find("Quantity (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = inventory.invList[i].quantity.ToString();
                itemDisplayed[inventory.invList[i]].transform.Find("ItemName (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = inventory.invList[i].item.DisplayName;
            }else{
                var obj = Instantiate(inventory.invList[i].item.inventorySlotPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.transform.Find("ItemName (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = inventory.invList[i].item.DisplayName;
                obj.transform.Find("Quantity (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = inventory.invList[i].quantity.ToString();
                itemDisplayed.Add(inventory.invList[i],obj);
            }
        }
    }
}
