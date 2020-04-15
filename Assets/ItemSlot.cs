using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    private string Name;
    public TextMeshProUGUI ButtonText;
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
}
