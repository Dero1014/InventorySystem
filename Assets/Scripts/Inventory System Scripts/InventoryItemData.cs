using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Loot,
    Consumable,
    Weapon,
    Armor
}

[CreateAssetMenu(fileName = "Item Data", menuName = "Inventory/ItemData")]
public class InventoryItemData : ScriptableObject
{
    public int ID;
    public ItemType ItemType;
    public string Name;
    public string Description;
    public int MaxSize;

    //public Image Sprite;
    public Color ItemColor;
}
