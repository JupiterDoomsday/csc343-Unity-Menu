using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the inventory object that gives us the list of items
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Invo : ScriptableObject
{
    public List<Item> inventory;

    public Invo() {
        inventory = new List<Item>();
    }

    //add new item
    public void addItem(Item itm, int a) {
        for (int i = 0; i < inventory.Count; i++) {
            if (inventory[i].id == itm.id)
            {
                inventory[i].amount+=a;
                return;
            }
        }
        inventory.Add(itm);
    }
    //a function to remove an item
    public Item removeItem(Item itm, int a)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].id == itm.id)
            {
                if (inventory[i].amount == a) {
                    Item temp = inventory[i];
                    inventory.RemoveAt(i);
                    return temp;
                }
            }
        }
        return null;
    }
}

//[System.Serializable]
public class InventorySlot {
    public Item item;
    public int amount;
    public InventorySlot(Item i, int a) {
        item = i;
        amount = a;
    }
    public void increment(int value)
    {
        amount += value;
    }
    public int decrement(int value) {
        if (value >= amount)
            amount = 0;
        else
            amount-=value;
        return amount;
    }

}