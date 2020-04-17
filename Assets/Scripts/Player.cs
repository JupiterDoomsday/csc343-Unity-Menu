using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //int addition
    public int hp;
    public int spd;
    public int def;
    public int mgc;
    public int atk;
    //bonusstats by items
    public int atkBns;
    public int spdBns;
    public int hpBns;
    public int defBns;
    public int mgcBns;
    //items equiped to player
    public Equipment head;
    public Equipment weapon;
    public Equipment top;
    public Equipment feet;

    //this updates the equpied list of items the user is Equiped to
    //if the user
    public Equipment replaceItem(Equipment eqItem)
    {
        Equipment temp = null;
        switch (eqItem.peice)
        {
            case (BodyPart.head):
                temp = head;
                head=eqItem;
                break;
            case (BodyPart.top):
                temp = top;
                top= eqItem;
                break;
            case (BodyPart.feet):
                temp = feet;
                feet= eqItem;
                break;
            case (BodyPart.weapon):
                temp = weapon;
                weapon=eqItem;
                break;
        }
        if (temp != null)
        {
            applyStats(temp, false);
            temp.equiped = false;
        }
        eqItem.equiped = true;
        applyStats(eqItem, true);
        return temp;
    }
    public Equipment removeEquipment(BodyPart part) {
        Equipment temp = null;
        if (part== BodyPart.head) {
            temp = head;
            head = null;
        }
        else if(part == BodyPart.top)
        {
            temp = top;
            top = null;
        }
        else if(part == BodyPart.feet)
        {
            temp = feet;
            feet = null;
        }
        else
        {
            temp = weapon;
            weapon = null;
        }
        if (temp == null)
            return null;
        applyStats(temp, false);
        temp.equiped = false;
        return temp;
    }

    private void applyStats(Equipment eqItem, bool b) {
        if (b)
        {
            hpBns += eqItem.hpBonus;
            atkBns += eqItem.atkBonus;
            defBns += eqItem.defBonus;
            mgcBns += eqItem.mgcBonus;
            spdBns += eqItem.spdBonus;
        }
        else
        {
            hpBns -= eqItem.hpBonus;
            atkBns -= eqItem.atkBonus;
            defBns -= eqItem.defBonus;
            mgcBns -= eqItem.mgcBonus;
            spdBns -= eqItem.spdBonus;
        }


    }

}
