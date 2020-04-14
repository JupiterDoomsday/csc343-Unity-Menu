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

    public Player user;
    // Start is called before the first frame update
    void Start()
    {
        setStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void setStats() {
        atk_amt.text = user.atk.ToString();
        spd_amt.text = user.spd.ToString();
        def_amt.text = user.def.ToString();
        hp_amt.text = user.hp.ToString();
    }

}
