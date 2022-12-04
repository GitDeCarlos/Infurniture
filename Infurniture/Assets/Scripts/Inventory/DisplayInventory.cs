using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventorySlotPrefab;
    public InventoryObj inventory;

    public int x_space;

    public int x_start;
    public int y_start;
    public int columns = 1;
    public int y_space;
    public int prevCount;

    Dictionary<GameObject, InventoryItem> itemDisplayed = new Dictionary<GameObject, InventoryItem>();

    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
        if (Input.GetKeyDown("2"))
        {
            inventory.nextItem();
        }
        if (Input.GetKeyDown("1"))
        {
            inventory.prevItem();
        }
        if (Input.GetKeyDown("r"))
        {
            inventory.removeItem(inventory.invList.Items[inventory.currSelected].item);
        }
    }

    public void CreateSlots()
    {
        itemDisplayed = new Dictionary<GameObject, InventoryItem>();
        for (int i = 0; i < inventory.invList.Items.Length; i++)
        {
            var obj = Instantiate(inventorySlotPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.transform.Find("ItemName (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = "";
            obj.transform.Find("Quantity (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = "";
            itemDisplayed.Add(obj, inventory.invList.Items[i]);
        }
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject,InventoryItem> slot in itemDisplayed)
        {
            if (slot.Value.ID >= 0)
            {
                slot.Key.transform.Find("ItemName (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = inventory.database.GetItem[slot.Value.item.Id].DisplayName;
                slot.Key.transform.Find("Quantity (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = slot.Value.quantity.ToString();
            }
            else
            {
                slot.Key.transform.Find("ItemName (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = "";
                slot.Key.transform.Find("Quantity (TMP)").GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    

    

    public Vector3 GetPosition(int i){
        return new Vector3(x_start + (x_space * ( i % columns)), y_start + (-y_space * (i/columns)), 0f);
    }

   
}
