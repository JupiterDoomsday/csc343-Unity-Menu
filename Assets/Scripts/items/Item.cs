using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Equipment,
    MISC
}
public abstract class Item : ScriptableObject
{
    public string title;
    public Sprite img;
    public ItemType type;
    public int id;
    public int amount;
    public int value;
    public bool equiped;
    [TextArea(15,20)]
    public string desc;
}
