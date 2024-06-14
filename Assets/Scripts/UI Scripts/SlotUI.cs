using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : InventoryUI
{
    protected Button _slotButton;
    private InventoryDisplayUI _inventoryDisplayUI;

    private void Awake()
    {
        ClearSlotUI();
        _slotButton = GetComponent<Button>();
        _inventoryDisplayUI = GetComponentInParent<InventoryDisplayUI>();
        _slotButton.onClick.AddListener(OnSlotUIClick);
    }

    public void ClearSlotUI()
    {
        _itemImage.color = Color.white;
        _itemStack.text = "";
        _itemSlot.ClearSlot();
    }

    public void InitSlotUI(ItemSlot slot)
    {
        _itemSlot = slot;

        UpdateSlotUI(slot);
    }

    public void UpdateSlotUI(ItemSlot slot)
    {
        if (slot?.ItemData != null)
        {
            _itemImage.color = slot.ItemData.GetColor();
            print("Stack size is " + slot.StackSize);
            if (_itemSlot.StackSize > 1)
                _itemStack.text = slot.StackSize.ToString();
            else
            {
                _itemStack.text = "";
            }
        }
        else
        {
            ClearSlotUI();
        }
    }

    public void UpdateSlotUI()
    {
        if (_itemSlot != null)
        {
            UpdateSlotUI(_itemSlot);
        }
    }

    public void OnSlotUIClick()
    {
        _inventoryDisplayUI?.SlotClickUI(this);
    }
}
