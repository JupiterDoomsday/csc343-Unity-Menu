using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public ItemType CurTab;
    public Invo menuList;
    public int xStart;
    public int yStart;
    public int XSpaceBtwItem;
    public int YSpaceBtwItem;
    public int ColNum;
    public Player user;
    Dictionary<Item, GameObject> displayed;
    private int amtItem;
    //public 
    // Start is called before the first frame update
    void Start()
    {
        displayed=new Dictionary<Item, GameObject>();
        amtItem = 0;
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }
    //
    public void CreateDisplay() {
        for (int i = 0; i < menuList.inventory.Count; i++) {
            if (menuList.inventory[i] == null)
                continue;
            var obj = Instantiate(menuList.inventory[i].prefab, Vector3.zero, Quaternion.identity, transform);
            displayed.Add(menuList.inventory[i],obj);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = menuList.inventory[i].name;
            if (menuList.inventory[i].type == CurTab)
            {
                obj.GetComponent<RectTransform>().localPosition = GetPosition(amtItem);
                amtItem++;
            }
            else{
                moveOffScreen(obj);
            }
              
        }
    }

    public Vector3 GetPosition( int i) {
        return new Vector3(0, yStart+ YSpaceBtwItem * i, 0f);
    }

    //this function equips an item to the player form the menu
    public void equipItem(Equipment eqItem) {
        Equipment used = null;
        switch (eqItem.peice) {
            case (BodyPart.head):
                used = user.replaceItem(user.head,eqItem);
                break;
            case (BodyPart.top):
                used = user.replaceItem(user.top,eqItem);
                break;
            case (BodyPart.feet):
                used = user.replaceItem(user.feet,eqItem);
                break;
            case (BodyPart.weapon):
                used = user.replaceItem(user.weapon,eqItem);
                break;
        }
        //move the swaped out item back into the inventory menu
        if (used != null) {
            menuList.addItem(used, used.amount);
        }
    }

    public void setToConsume() {
        CurTab = ItemType.Consumable;
    }
    public void setToEquipment()
    {
        CurTab = ItemType.Equipment;
    }
    public void setToMisc()
    {
        CurTab = ItemType.MISC;
    }

    private void moveOffScreen(GameObject obj) {
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-1000,-1000, 0f);
    }

    public void UpdateDisplay()
    {
        amtItem = 0;
        for (int i = 0; i < menuList.inventory.Count; i++)
        {
            if (displayed.ContainsKey(menuList.inventory[i])==false)
            {
                var obj = Instantiate(menuList.inventory[i].prefab, Vector3.zero, Quaternion.identity, transform);
                displayed.Add(menuList.inventory[i], obj);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = menuList.inventory[i].name;
            }
            if (menuList.inventory[i].type == CurTab && menuList.inventory[i].equiped ==false)
            {
                displayed[menuList.inventory[i]].GetComponent<RectTransform>().localPosition = GetPosition(amtItem);
                amtItem++;
            }
            else
            {
                moveOffScreen(displayed[menuList.inventory[i]]);
            }
        }
    }

}
