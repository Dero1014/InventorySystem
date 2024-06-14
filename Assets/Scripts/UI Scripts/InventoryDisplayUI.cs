using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryDisplayUI : MonoBehaviour
{
    [SerializeField] protected MouseSlot _mouseSlot;
    [SerializeField] protected InventorySystem _inventorySystem;
    [SerializeField] protected InventoryHolder _inventoryHolder;
    [SerializeField] protected Dictionary<SlotUI, ItemSlot> _inventoryDisplay = new Dictionary<SlotUI, ItemSlot>();
    [SerializeField] protected SlotUI[] _slotsUI;

    public abstract void AssignSlotUI(InventorySystem invToDisplay);

    protected void Start()
    {
        _mouseSlot = FindObjectOfType<MouseSlot>();
        _slotsUI = GetComponentsInChildren<SlotUI>();
        _inventorySystem = _inventoryHolder.InventorySystem;
        _inventoryHolder.InventorySystem.OnInventorySlotChanged += UpdateSlotsUI;
        InitDisplay();
    }

    void InitDisplay()
    {
        if (_inventoryHolder.InventorySystem.InventorySize != _slotsUI.Length)
        {
            Debug.Log("Slots don't match");
        }

        for (int i = 0; i < _inventoryHolder.InventorySystem.InventorySize; i++)
        {
            _inventoryDisplay.Add(_slotsUI[i], _inventoryHolder.InventorySystem.ItemSlots[i]);
            _slotsUI[i].InitSlotUI(_inventoryHolder.InventorySystem.ItemSlots[i]);

        }
    }

    void UpdateSlotsUI(ItemSlot slotToUpdate)
    {
        foreach (var slot in _inventoryDisplay)
        {
            if (slot.Value == slotToUpdate)
            {
                slot.Key.UpdateSlotUI(slotToUpdate);
            }
        }
    }
    // Clicking on a slot is our interaction
    // Check if mouse slot already has an item
    // If it doesn't have a slot, clicking will add the item to the mouse slot
    // Adding the item to the mouse slot we want to remove the item from the SlotUI and ItemSlot
    // While holding an item
    // If slot is empty do nothing
    public void SlotClickUI(SlotUI clickedSlot)
    {
        print($"Click {clickedSlot}");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(_mouseSlot.Slot.ItemData == null)
            {
                print("enter here");
                _mouseSlot.SplitSlot(clickedSlot);
                return;
            }
        }


        if (_mouseSlot.Slot.ItemData != null )
        {
            if (clickedSlot.Slot.ItemData != null)
            {
                if (clickedSlot.Slot.ItemData == _mouseSlot.Slot.ItemData)
                {
                    // combine
                    // check if adding mouse slot stack to the clicked slot will have remaining
                    _mouseSlot.CombineSlots(clickedSlot);

                    return;
                }
                _mouseSlot.SwapSlots(clickedSlot);
                return;
            }
            clickedSlot.Slot.AssignSlot(_mouseSlot.Slot);
            clickedSlot.UpdateSlotUI();
            _mouseSlot.ClearMouseSlot();
        }
        else
        {
            if(clickedSlot.Slot.ItemData != null)
            {
                _mouseSlot.UpdateMouseSlot(clickedSlot);
                clickedSlot.ClearSlotUI();
                return;
            }
        }
    }

}
