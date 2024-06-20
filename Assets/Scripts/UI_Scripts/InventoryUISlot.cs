using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryUISlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _stackText;
    [SerializeField] private Image _itemImage;
    [SerializeField] private InventorySlot _assignedSlot;

    private InventoryMouseSlot _mouseSlot;

    public InventorySlot AssignedSlot => _assignedSlot;

    void Start()
    {
        _stackText = GetComponentInChildren<TextMeshProUGUI>();
        _itemImage = GetComponentInChildren<Image>();
        _mouseSlot = FindObjectOfType<InventoryMouseSlot>();
    }

    public void AssignSlotToUI(InventorySlot slot)
    {
        _assignedSlot = slot;
    }

    public void UpdateSlotUI()
    {
        if (_assignedSlot.InventoryItemData != null)
        {
            _stackText.text = _assignedSlot.StackSize.ToString();
            _itemImage.color = _assignedSlot.InventoryItemData.ItemColor;
        }
        else
        {
            _stackText.text = "";
            _itemImage.color = Color.white;
        }
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // On click check if Inventory mouse is empty or full
        if (_mouseSlot.AssignedSlot.InventoryItemData == null)
        {
            print("me be null");
            // If mouse empty then give the mouse the slot
            _mouseSlot.UpdateSlot(_assignedSlot.InventoryItemData, _assignedSlot.StackSize);
            _assignedSlot.ClearSlot();
            UpdateSlotUI();
            _mouseSlot.UpdateUI();
        }
        else if (_mouseSlot.AssignedSlot.InventoryItemData != null)
        {
            // If mouse not empty but the slot is then give slot
            if (_assignedSlot.InventoryItemData == null)
            {
                print("Yup nothing there");
                _assignedSlot.AssignItem(_mouseSlot.AssignedSlot.InventoryItemData, _mouseSlot.AssignedSlot.StackSize);
                _mouseSlot.ClearSlot();
            }
            else
            {
                print("Owo what you got there");
                // If mouse not empty and slot not empty
                // check if the slots are the same
                if (_mouseSlot.AssignedSlot.InventoryItemData == _assignedSlot.InventoryItemData)
                {
                    // try to add to the slot
                    print("OMG YOU WE SAME");
                    int remaining;
                    if (_assignedSlot.RemainingStack(_mouseSlot.AssignedSlot.StackSize, out remaining))
                    {
                        _assignedSlot.AddAmount(_mouseSlot.AssignedSlot.StackSize);
                        _mouseSlot.ClearSlot();
                    }
                    else if (remaining < 0)
                    {
                        _assignedSlot.AddAmount(_mouseSlot.AssignedSlot.StackSize + remaining);
                        _mouseSlot.AssignedSlot.RemoveAmount(-remaining);
                    }
                }
                else
                {
                    var tempItem = _mouseSlot.AssignedSlot.InventoryItemData;
                    var tempStack = _mouseSlot.AssignedSlot.StackSize;

                    _mouseSlot.UpdateSlot(_assignedSlot.InventoryItemData, _assignedSlot.StackSize);
                    _assignedSlot.AssignItem(tempItem, tempStack);
                    
                }
            }
            _mouseSlot.UpdateUI();
            UpdateSlotUI();
        }
    }

}
