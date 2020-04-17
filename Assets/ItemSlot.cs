using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private string Name;
    public TextMeshProUGUI ButtonText;
    public Image itemImg;
    public DisplayInventory ScrollView;
    public void SetName(string name)
    {
        Name = name;
        ButtonText.text = name;
    }

    public void Button_Click()
    {
        ScrollView.ButtonClicked(Name);
    }
    public void onHover()
    {
        ScrollView.overButton(Name);
    }
    public void onExit()
    {
        ScrollView.clearTextBox();
    }
}
