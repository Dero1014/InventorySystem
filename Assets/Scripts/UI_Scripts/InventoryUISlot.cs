using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stackText;
    [SerializeField] private Image _itemImage;
    [SerializeField] private InventorySlot _assignedSlot;
    public InventorySlot AssignedSlot => _assignedSlot;

    void Start()
    {
        _stackText = GetComponentInChildren<TextMeshProUGUI>();
        _itemImage = GetComponentInChildren<Image>();
    }

    public void AssignSlotToUI(InventorySlot slot)
    {
        _assignedSlot = slot;
    }

    public void UpdateSlotUI()
    {
        print(_itemImage);
        _itemImage.color = _assignedSlot.InventoryItemData.ItemColor;
        _stackText.text = _assignedSlot.StackSize.ToString();
    }
    
}
