using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : Interactable
{
    public Item myItem;

    public override void Interact()
    {
        Debug.Log("Collect " + myItem.itemName);
        GameManager.ins.itemHeld = myItem;
        GameManager.ins.inventoryDisplay.UpdateDisplay();
    }
}
