using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField]
    private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

    public List<InventorySlot> InventorySlots => _inventorySlots;

    public InventoryUIDisplay InventoryDisplay;

    //public UnityEvent UpdateSlotEvent = new UnityEvent();
    
    public void InitSlot()
    {
        InventorySlot slot = new InventorySlot();
        slot.InitilzeSlot();
        _inventorySlots.Add(slot);
    }

    public bool AddToInventory(InventoryItemData itemData, int amount = 1)
    {
        bool result = false;
        InventorySlot slot;
        if (CheckExistingSlot(itemData, out slot))
        {
            // Add amount
            slot.AddAmount(amount);
            result = true;
        }
        else if (CheckFreeSlot(itemData, out slot))
        {
            // store item
            slot.AssignItem(itemData, amount + 1);
            result = true;
        }

        if (result)
        {
            foreach (var uiSlot in InventoryDisplay.InventoryUISlots)
            {
                if (uiSlot.AssignedSlot == slot)
                {
                    uiSlot.UpdateSlotUI();
                }
            }
        }

        return result;
    }

    public bool CheckExistingSlot(InventoryItemData itemData, out InventorySlot existingSlot, int amount = 1)
    {
        existingSlot = null;
        foreach (InventorySlot slot in _inventorySlots) 
        {
            if (slot.InventoryItemData == itemData)
            {
                // Check if it has room
                if (slot.RemainingStack(1))
                {
                    existingSlot = slot;
                    return true;
                }
            }
        }

        return false;
    }

    public bool CheckFreeSlot(InventoryItemData itemData, out InventorySlot freeSlot, int amount = 1)
    {
        freeSlot = null;
        foreach (InventorySlot slot in _inventorySlots)
        {
            if (slot.InventoryItemData == null)
            {
                freeSlot = slot;
                return true;
            }
        }

        return false;
    }

}
