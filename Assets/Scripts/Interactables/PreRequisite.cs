using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreRequisite : MonoBehaviour
{
    public bool requireItem;

    public Switcher watchSwitcher;
    public bool nodeAccess;

    public Collector checkCollector;

    public bool Complete
    {
        get { 
            if (!requireItem)
            {
                return watchSwitcher.state;
            }
            else
            {
                return GameManager.ins.itemHeld.itemName == checkCollector.myItem.itemName;
            }       
        }
    }
}
