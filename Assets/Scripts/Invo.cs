using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the inventory object that gives us the list of items 
public class Invo : ScriptableObject
{
    public List<Item> inventory;

    public Invo() {
        inventory = new List<Item>();
    }

    //return the list 
    public List<Item> getList() {
        return inventory;
    }

    public void addItem(Item i) {
        if (inventory.Contains(i))
            i.amount++;
        inventory.Add(i);
    }

    public void removeItem(Item i) {
        inventory.Remove(i);
    }
}

[System.Serializable]
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

}
