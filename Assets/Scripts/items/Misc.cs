﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Misc Item", menuName = "Inventory System/Items/misc")]
public class Misc : Item
{
    public int puzzelID;
    public void Awake()
    {
        type = ItemType.MISC;
    }
    public bool isKey(int id) {
        return this.puzzelID == id;
    }
}