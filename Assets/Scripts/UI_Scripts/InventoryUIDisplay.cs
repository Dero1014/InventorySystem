using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUIDisplay : MonoBehaviour
{
    public InventoryHolder InventoryHolder;
    [SerializeField]
    private InventorySystem _inventorySystem;
    [SerializeField]
    private InventoryUISlot[] _inventoryUISlots;
    public InventoryUISlot[] InventoryUISlots => _inventoryUISlots;

    private InventoryMouseSlot _mouseSlot;

    void Start()
    {
        _inventoryUISlots = GetComponentsInChildren<InventoryUISlot>();
        _inventorySystem = InventoryHolder.InventorySystem;
        _mouseSlot = FindObjectOfType<InventoryMouseSlot>();

        InitilizeDisplay();
    }

    void InitilizeDisplay()
    {
        for (int i = 0; i < _inventoryUISlots.Length; i++)
        {
            _inventoryUISlots[i].AssignSlotToUI(_inventorySystem.InventorySlots[i]);
        }
    }

    // Update is called once per frame
    public void OnSlotClick(InventoryUISlot clickedUISlot)
    {
        // On click check if Inventory mouse is empty or full
        if (_mouseSlot.AssignedSlot.InventoryItemData == null)
        {
            
            // If mouse empty then give the mouse the slot
            _mouseSlot.UpdateSlot(clickedUISlot.AssignedSlot.InventoryItemData, clickedUISlot.AssignedSlot.StackSize);
            clickedUISlot.AssignedSlot.ClearSlot();

            clickedUISlot.UpdateSlotUI();
            _mouseSlot.UpdateUI();

        }
        else if (_mouseSlot.AssignedSlot.InventoryItemData != null)
        {
            // If mouse not empty but the slot is then give slot
            if (clickedUISlot.AssignedSlot.InventoryItemData == null)
            {
                clickedUISlot.AssignedSlot.AssignItem(_mouseSlot.AssignedSlot.InventoryItemData, _mouseSlot.AssignedSlot.StackSize);
                _mouseSlot.ClearSlot();
            }
            else
            {
                // If mouse not empty and slot not empty
                // check if the slots are the same
                if (_mouseSlot.AssignedSlot.InventoryItemData == clickedUISlot.AssignedSlot.InventoryItemData)
                {
                    // try to add to the slot
                    int remaining;
                    if (clickedUISlot.AssignedSlot.RemainingStack(_mouseSlot.AssignedSlot.StackSize, out remaining))
                    {
                        clickedUISlot.AssignedSlot.AddAmount(_mouseSlot.AssignedSlot.StackSize);
                        _mouseSlot.ClearSlot();
                    }
                    else if (remaining < 0)
                    {
                        if (_mouseSlot.AssignedSlot.StackSize + remaining != 0)
                        {
                            clickedUISlot.AssignedSlot.AddAmount(_mouseSlot.AssignedSlot.StackSize + remaining);
                            _mouseSlot.AssignedSlot.RemoveAmount(-remaining);
                        }
                        else
                        {
                            Swap(clickedUISlot);
                        }
                    }
                }
                else
                {
                    Swap(clickedUISlot);
                }
            }
            _mouseSlot.UpdateUI();
            clickedUISlot.UpdateSlotUI();
        }
    }

    void Swap(InventoryUISlot clickedUISlot)
    {
        var tempItem = _mouseSlot.AssignedSlot.InventoryItemData;
        var tempStack = _mouseSlot.AssignedSlot.StackSize;

        _mouseSlot.UpdateSlot(clickedUISlot.AssignedSlot.InventoryItemData, clickedUISlot.AssignedSlot.StackSize);
        clickedUISlot.AssignedSlot.AssignItem(tempItem, tempStack);
    }


}
