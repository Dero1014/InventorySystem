using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseSlot : InventoryUI
{
    private void Start()
    {
    }

    private void Update()
    {
        /*
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponentInParent<Canvas>().transform as RectTransform, Input.mousePosition, GetComponentInParent<Canvas>().worldCamera, out pos);
        transform.position = GetComponentInParent<Canvas>().transform.TransformPoint(pos);
        */
    }

    public void UpdateMouseSlot(SlotUI clickedSlot)
    {
        _itemSlot.AssignSlot(clickedSlot.Slot);
        _itemImage.color = _itemSlot.ItemData.GetColor();
        _itemStack.text = _itemSlot.StackSize.ToString();
    }

    public void UpdateMouseSlot()
    {
        if (_itemSlot.ItemData != null)
        {
            _itemImage.color = _itemSlot.ItemData.GetColor();
            _itemStack.text = _itemSlot.StackSize.ToString();
        }
    }

    public void SwapSlots(SlotUI clickedSlot)
    {
        var clonedSlot = new ItemSlot(_itemSlot.ItemData, _itemSlot.StackSize);
        ClearMouseSlot();
        UpdateMouseSlot(clickedSlot);
        clickedSlot.ClearSlotUI();
        clickedSlot.Slot.AssignSlot(clonedSlot);
        clickedSlot.UpdateSlotUI();
    }

    public void CombineSlots(SlotUI clickedSlot)
    {
        bool enough = clickedSlot.Slot.RoomLeftInStack(_itemSlot.StackSize, out int remaining);
        if (enough)
        {
            clickedSlot.Slot.AddToStack(_itemSlot.StackSize);
            ClearMouseSlot() ;
            clickedSlot.UpdateSlotUI();
        }
        else if (remaining > 0)
        {
            clickedSlot.Slot.AddToStack(remaining);
            _itemSlot.RemoveFromStack(remaining);
            UpdateMouseSlot();
            clickedSlot.UpdateSlotUI();
        }else if (remaining == 0)
        {
            SwapSlots(clickedSlot);
        }
    }

    public void SplitSlot(SlotUI clickedSlot)
    {
        if (clickedSlot.Slot.StackSize > 1)
        {
            clickedSlot.Slot.RemoveFromStack(clickedSlot.Slot.StackSize/2);
            clickedSlot.UpdateSlotUI();
            UpdateMouseSlot(clickedSlot);
        }
    }

    public void ClearMouseSlot()
    {
        _itemSlot.ClearSlot();
        _itemImage.color = Color.white;
        _itemStack.text = 0.ToString();
    }
}
