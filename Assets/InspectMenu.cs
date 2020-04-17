using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InspectMenu : MonoBehaviour
{
    public Image imgCloseUp;
    public TextMeshProUGUI moreDesc;

    public void clearItems() {
        imgCloseUp.sprite = null;
        moreDesc.text = "";
    }
}
