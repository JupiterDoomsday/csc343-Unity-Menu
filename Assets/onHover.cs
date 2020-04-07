using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHover : MonoBehaviour
{
    public TextMesh textBox;
    public InventorySlot slot;

    void OnMouseOver()
    {
        textBox.text = slot.item.desc;
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        textBox.text = "";
    }
}
