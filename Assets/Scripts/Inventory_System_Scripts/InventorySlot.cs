using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    [SerializeField]
    private InventoryItemData _inventoryItemData;
    [SerializeField]
    private int _stackSize;

    public InventoryItemData InventoryItemData => _inventoryItemData;
    public int StackSize => _stackSize;

    public void InitilzeSlot()
    {
        _inventoryItemData = null;
        _stackSize = -1;
    }

    public void AssignItem(InventoryItemData inventoryItemData, int amount = 0)
    {
        _inventoryItemData = inventoryItemData;
        _stackSize = amount;
    }

    public void AddAmount(int amount)
    {
        _stackSize += amount;
    }

    public void RemoveAmount(int amount)
    {
        _stackSize -= amount;
    }

    public bool RemainingStack(int amount, out int remaining)
    {
        bool result = false;
        remaining = _inventoryItemData.MaxSize - _stackSize - amount;
        if (remaining >= 0)
        {
            result = true;
        }
        return result;
    }

    public bool RemainingStack(int amount)
    {
        int value;
        return RemainingStack(amount, out value);
    }

    public void ClearSlot()
    {
        _inventoryItemData = null;
        _stackSize = 0;
    }



}
