using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public PopUpDisplay backBtn;
    public PopUpDisplay trashBtn;
    public PopUpDisplay itrActBtn;
    public GameObject trash;
	public GameObject popupui;
	int y;

    public void setInteraction(ItemType type) {
        if (type == ItemType.Consumable)
            itrActBtn.BtnText.text = "Eat";
        else if(type == ItemType.MISC)
            itrActBtn.BtnText.text = "Inspect";
        else
            itrActBtn.BtnText.text = "Equip";
    }
}
