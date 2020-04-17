using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
	public TextMeshProUGUI posText;
    public TextMeshProUGUI itemText;
    public Image imgSprite;
    public DisplayInventory ScrollView;
    public BodyPart pos;
    // Start is called before the first frame update
    public void hover()
    {
        //PosText.color = Color.green;
		itemText.color = Color.black;

	}

    // Update is called once per frame
    public void mOff()
    {
		itemText.color = Color.white;
        
    }
    public void onClick() {
        ScrollView.RemoveItem(pos);
    }
}
