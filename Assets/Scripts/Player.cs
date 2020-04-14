using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public int spd;
    public int def;
    public int mgc;
    public int atk;
    public Equipment head;
    public Equipment weapon;
    public Equipment top;
    public Equipment feet;
    public Invo inventory;

    //this updates the equpied list of items in the user inventory
    public Equipment replaceItem(Equipment target, Equipment eqItem)
    {
        Equipment temp = null;
        if (target != null)
        {
            temp = target;
        }
        target = eqItem;
        eqItem.equiped = true;
        temp.equiped = false;
        return temp;
    }
}
