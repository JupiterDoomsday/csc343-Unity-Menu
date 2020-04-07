using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Equip Item", menuName = "Inventory System/Items/consumable")]
public class Equipment : Item
{
    public int hpBonus;
    public int defBonus;
    public int atkBonus;
    public int mgcBonus;
    public int spdBonus;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
