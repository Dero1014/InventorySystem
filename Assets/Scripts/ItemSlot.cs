using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    [SerializeField]
    private ItemData _itemData;
    [SerializeField]
    private int _stackSize;

    public ItemData ItemData => _itemData;
    public int StackSize => _stackSize;

    public ItemSlot(ItemData itemData, int amount)
    {
        _itemData = itemData;
        _stackSize = amount;
    }

    public ItemSlot()
    {
       ClearSlot();
    }

    public void ClearSlot()
    {
        _itemData = null;
        _stackSize = -1;
    }

    public void AssignSlot(ItemSlot newSlot)
    {
        if (ItemData == newSlot.ItemData) AddToStack(newSlot.StackSize);
        else
        {
            _itemData = newSlot.ItemData;
            _stackSize = 0;
            AddToStack(newSlot.StackSize);
        }
    }

    public void AssignSlot()
    {
        if (ItemData != null)
        {
            AssignSlot(this);
        }
    }


    public bool RoomLeftInStack(int amountToAdd, out int remaining)
    {
        remaining = ItemData.GetMaxStack() - StackSize;

        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd)
    {
        bool result = false;
        if (_stackSize + amountToAdd <= _itemData.GetMaxStack())
            result = true;

        return result;
    }

    public bool AddToStack(int amount)
    {
        
        if (RoomLeftInStack(1))
        {
            _stackSize += amount;
            return true;
        }
        else
        {
            Debug.Log("Stack size full");
            return false;
        }
    }

    public void UpdateSlot(ItemData newItemData, int amount)
    {
        _itemData = newItemData;
        _stackSize = amount;
    }

    public void UpdateSlot(ItemData newItemData)
    {
        _itemData = newItemData;
    }

    public void RemoveFromStack(int amount)
    {
        _stackSize -= amount;
    }
}
