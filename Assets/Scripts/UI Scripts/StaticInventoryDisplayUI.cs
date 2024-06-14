using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplayUI : InventoryDisplayUI
{
    private void Start()
    {
        base.Start();
    }

    public override void AssignSlotUI(InventorySystem invToDisplay)
    {
        foreach (var slot in _inventoryDisplay)
        {

        }
    }
}
