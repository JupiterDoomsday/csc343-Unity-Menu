using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpDisplay : MonoBehaviour
{
    public TextMeshProUGUI BtnText;

    public void onHover()
    {
        BtnText.color= Color.green;
    }
    public void onExit()
    {
        BtnText.color = Color.white;
    }
}
