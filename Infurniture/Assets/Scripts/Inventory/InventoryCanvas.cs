using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    public GameObject inventoryPanel;
     public bool isShowing = false;

    
    // Update is called once per frame
    void Update()
    {
        inventoryPanel.SetActive(isShowing);
        if (Input.GetKeyDown("i")) {
            isShowing = !isShowing;
            //canvas.SetActive(isShowing);
            //print("button was pressed");
        }
    }
}
