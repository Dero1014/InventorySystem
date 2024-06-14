using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    public Image _itemImage;
    [SerializeField]
    protected TextMeshProUGUI _itemStack;

    [SerializeField]
    protected ItemSlot _itemSlot = null;

    

    public ItemSlot Slot => _itemSlot;


    private void Awake()
    {
        _itemImage.color = Color.white;
        _itemStack.text = "";
    }
}
