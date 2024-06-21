using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryMouseSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stackText;
    [SerializeField] private Image _itemImage;
    [SerializeField] private InventorySlot _assignedSlot = new InventorySlot();
    public InventorySlot AssignedSlot => _assignedSlot;

    void Start()
    {
        _stackText = GetComponentInChildren<TextMeshProUGUI>();
        _itemImage = GetComponentInChildren<Image>();
    }

    public void UpdateSlot(InventoryItemData itemData, int stack)
    {
        _assignedSlot.AssignItem(itemData, stack);
    }

    public void ClearSlot()
    {
        _assignedSlot.ClearSlot();
    }

    public void UpdateUI()
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
}
