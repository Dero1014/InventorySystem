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

    private InventoryUIDisplay _myInventoryDisplay;

    public InventorySlot AssignedSlot => _assignedSlot;

    void Start()
    {
        _stackText = GetComponentInChildren<TextMeshProUGUI>();
        _itemImage = GetComponentInChildren<Image>();
        _myInventoryDisplay = GetComponentInParent<InventoryUIDisplay>();
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
        _myInventoryDisplay.OnSlotClick(this);
    }

}
