using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public ItemType CurTab;
    public Invo inventory;
    public int xStart;
    public int yStart;
    public int XSpaceBtwItem;
    public int YSpaceBtwItem;
    public int ColNum;
    Dictionary<InventorySlot, GameObject> displayed;
    
    //public 
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisplay();
    }
    //
    public void CreateDisplay() {
        for (int i = 0; i < inventory.inventory.Count; i++) {
            if (inventory.inventory[i] == null)
                continue;
            if (CurTab == inventory.inventory[i].type) {
                var obj = Instantiate(inventory.inventory[i].prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.inventory[i].name;
            }
        }
    }

    public Vector3 GetPosition( int i) {
        return new Vector3(xStart+ XSpaceBtwItem * i, yStart+ YSpaceBtwItem * i, 0f);
    }   
}
