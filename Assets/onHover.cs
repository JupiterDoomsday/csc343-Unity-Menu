using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onHover : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    //public TextMeshProUGUI textBox;
    void Start()
    {

    }
    void OnMouseOver()
    {
        //textBox.text = slot.item.desc;
        itemText.color = Color.red;
    }
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //textBox.text = "";
        itemText.color = Color.white;
    }
}
