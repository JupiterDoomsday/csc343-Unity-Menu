using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public ItemType CurTab;
    public Invo defaultBag;
    public Invo menuList;
    Dictionary<Item, GameObject> displayed;

    public Item curItem;
    public int yStart;
    public GameObject popupScreen;
    public PopUp popup;
    public int XSpaceBtwItem;
    public int YSpaceBtwItem;
    public int ColNum;
    public TextMeshProUGUI descBox;
    public GameObject prefab;
    public Player user;
    private int amtItem;

    // Start is called before the first frame update
    void Start()
    {
        displayed =new Dictionary<Item, GameObject>();
        amtItem = 0;
        curItem = null;
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //
    public void CreateDisplay() {
        for (int i = 0; i < menuList.inventory.Count; i++) {
            if (menuList.inventory[i] == null)
                continue;
            var obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
            ItemSlot temp = obj.GetComponentInChildren<ItemSlot>();
            displayed.Add(menuList.inventory[i],obj);
            temp.SetName(menuList.inventory[i].name);
            temp.itemImg.sprite = menuList.inventory[i].img;
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
        used = user.replaceItem(eqItem);
        //move the swaped out item back into the inventory menu
        if (used != null) {
            menuList.addItem(used, used.amount);
        }
        //update menu display
        moveOffScreen(displayed[curItem]);
        popupScreen.SetActive(false);
        UpdateDisplay();
    }


    public void setToConsume() {
        CurTab = ItemType.Consumable;
        UpdateDisplay();
    }
    public void setToEquipment()
    {
        CurTab = ItemType.Equipment;
        UpdateDisplay();
    }
    public void setToMisc()
    {
        CurTab = ItemType.MISC;
        UpdateDisplay();
    }

    private void moveOffScreen(GameObject obj) {
        obj.GetComponent<RectTransform>().localPosition = new Vector3(-1000,-1000, 0f);
    }
//this updates all the inventory lists when we change the tab or equip an item
    public void UpdateDisplay()
    {
        amtItem = 0;
        for (int i = 0; i < menuList.inventory.Count; i++)
        {
            if (displayed.ContainsKey(menuList.inventory[i])==false)
            {
                var obj = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
                displayed.Add(menuList.inventory[i], obj);
                ItemSlot temp = obj.GetComponentInChildren<ItemSlot>();
                displayed.Add(menuList.inventory[i], obj);
                temp.SetName(menuList.inventory[i].name);
                temp.itemImg.sprite = menuList.inventory[i].img;
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
//this function is called when an item is clicked on
    public void ButtonClicked(string str)
    {
        Debug.Log(str + " button clicked.");
       // curItem = menuList.getItem(str);
        if (curItem != null)
        {
            popup.setInteraction(curItem.type);
            if (curItem.isDisposable == false)
                popup.trash.SetActive(false);
            else
                popup.trash.SetActive(true);
            popupScreen.SetActive(true);
        }
            
    }
//this function unequips an item when the user clicks on it
    public void RemoveItem( BodyPart str) {
         Equipment eq = user.removeEquipment(str);
         if (eq != null)
            {
                menuList.addItem(eq, eq.amount);
                UpdateDisplay();
            }           
    }
//this function is called when a mouse hovers over an item object
    public void overButton(string str)
    {
        curItem = menuList.getItem(str);
        ChangeItemColor(true);
        if (curItem != null)
        {
            descBox.text = curItem.desc;
        }
    }
//this is a function that is called to change the items color
    public void ChangeItemColor(bool status) {
        if (curItem == null)
            return;
        if (status)
            displayed[curItem].GetComponent<ItemSlot>().ButtonText.color = Color.green;
        else
            displayed[curItem].GetComponent<ItemSlot>().ButtonText.color = Color.white;
    }
//this is a healper function that clears the item textbox
    public void clearTextBox() {
        descBox.text = "";
        ChangeItemColor(false);
        //curItem = null;
    }
    //this button is called when we interact with the object
    public void interactWithObject() {
        if (curItem.type == ItemType.Consumable)
        {
            cosumeItem((Consumable) curItem);
        }
        else if(curItem.type == ItemType.Equipment)
        {
            equipItem((Equipment)curItem);
        }
    }
//this is a helper function to dispose the item
    public void disposeItem() {
        if (curItem == null)
            return;
        menuList.removeItem(curItem, curItem.amount);
        moveOffScreen(displayed[curItem]);
        UpdateDisplay();
        popupScreen.SetActive(false);
    }

//this resets our player inventory so we can reset our user tests over and over
    void OnApplicationQuit() {
        for (int i = 0; i < defaultBag.inventory.Count; i++)
        {
            defaultBag.inventory[i].equiped = false;
            if (menuList.hasItem(defaultBag.inventory[i]) == false)
            {
                menuList.addItem(defaultBag.inventory[i], defaultBag.inventory[i].amount);
            }
        }
    }
//this function allows us to consume an item
    private void cosumeItem(Consumable food)
    {
        user.hp += food.health;
        disposeItem();
    }

}
