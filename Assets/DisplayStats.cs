using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public TextMeshProUGUI atk_amt;
    public TextMeshProUGUI def_amt;
    public TextMeshProUGUI spd_amt;
    public TextMeshProUGUI hp_amt;
    public TextMeshProUGUI mgk_amt;
    public EquipSlot wSlot;
    public EquipSlot headSlot;
    public EquipSlot topSlot;
    public EquipSlot feetSlot;

    public Player user;
    // Start is called before the first frame update
    void Start()
    {
        setStats();
    }
    private void Update()
    {
        setStats();
        showWepons();
    }

    public void setStats() {
        atk_amt.text = (user.atk + user.atkBns).ToString();
        spd_amt.text = (user.spd+user.spdBns).ToString();
        def_amt.text = (user.def+user.defBns).ToString();
        hp_amt.text = (user.hp+user.hpBns).ToString();
        mgk_amt.text = (user.mgc+user.mgcBns).ToString();
    }
    //very messy function on setting up the items
    public void showWepons() {
        if (user.head != null)
        {
            headSlot.itemText.text = user.head.name;
            headSlot.imgSprite.sprite = user.head.img;
            headSlot.imgSprite.enabled = true;
        }
        else
        {
            headSlot.itemText.text = "";
            headSlot.imgSprite.sprite = null;
            headSlot.imgSprite.enabled = false;
        }
        if (user.top != null)
        {
            topSlot.itemText.text = user.top.name;
            topSlot.imgSprite.sprite = user.top.img;
            topSlot.imgSprite.enabled = true;
        }
        else
        {
            topSlot.itemText.text = "";
            topSlot.imgSprite.sprite = null;
            topSlot.imgSprite.enabled = false;
        }
        if (user.feet != null) {
            feetSlot.itemText.text = user.feet.name;
            feetSlot.imgSprite.sprite = user.feet.img;
            feetSlot.imgSprite.enabled = true;
        }
        else
        {
            feetSlot.itemText.text = "";
            feetSlot.imgSprite.sprite = null;
            feetSlot.imgSprite.enabled = false;
        }
        if (user.weapon != null)
        {
            wSlot.itemText.text = user.weapon.name;
            wSlot.imgSprite.sprite = user.weapon.img;
            wSlot.imgSprite.enabled = true;
        }
        else
        {
            wSlot.itemText.text = "";
            wSlot.imgSprite.sprite = null;
            wSlot.imgSprite.enabled = false;
        }

    }

}
