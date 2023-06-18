using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    Text displayText;

    void Start()
    {
        displayText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        string displayName = "none";
        if (GameManager.ins.itemHeld.itemName != "")
        {
            displayName = GameManager.ins.itemHeld.itemName;
        }
        displayText.text = "Inventory: " + displayName;
    }
}
