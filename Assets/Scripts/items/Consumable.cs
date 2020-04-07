using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Consume Item", menuName = "Inventory System/Items/consumable")]
public class Consumable : Item
{
    public int health;
    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
