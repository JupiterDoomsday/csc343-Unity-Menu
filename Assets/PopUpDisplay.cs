using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveOffScreen()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3(3000, 0, 0f);
    }
}
