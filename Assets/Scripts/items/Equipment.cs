using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPart {
    head,
    arm,
    feet,
    chest,
    legs,
}
[CreateAssetMenu(fileName = "new Equip Item", menuName = "Inventory System/Items/equipment")]
public class Equipment : Item
{
    public int hpBonus;
    public int defBonus;
    public int atkBonus;
    public int mgcBonus;
    public int spdBonus;
    public BodyPart peice;
    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
