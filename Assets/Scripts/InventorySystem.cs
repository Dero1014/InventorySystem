using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using Unity.Collections.LowLevel.Unsafe;

[System.Serializable]
public class InventorySystem
{

    [SerializeField] private List<ItemSlot> _itemSlots;

    public List<ItemSlot> ItemSlots => _itemSlots;

    public int InventorySize => ItemSlots.Count;

    public UnityAction<ItemSlot> OnInventorySlotChanged;
    
    public InventorySystem(int size)
    {
        _itemSlots = new List<ItemSlot>();

        for (int i = 0; i < size; i++)
        {
            _itemSlots.Add(new ItemSlot());
        }
    }

    public bool AddItemToInventory(ItemData itemData)
    {
        if(ContainItem(itemData, out List<ItemSlot> itemSlots))
        {
            foreach (var slot in itemSlots)
            {
                if (slot.AddToStack(1))
                {
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
            Debug.Log("Contains");
        }

        if(HasFreeSlot(out ItemSlot freeSlot))
        {
            freeSlot.UpdateSlot(itemData, 1);
            OnInventorySlotChanged?.Invoke(freeSlot);
            Debug.Log("Free");
            return true;
        }
        return false;
    }

    public bool ContainItem(ItemData itemToAdd, out List<ItemSlot> itemSlots)
    {
        itemSlots = ItemSlots.Where(i => i.ItemData == itemToAdd).ToList();
        return itemSlots.Count > 0 ? true : false;
    }

    public bool HasFreeSlot(out ItemSlot freeSlot)
    {
        freeSlot = null;

        freeSlot = ItemSlots.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false : true;
    }
}
