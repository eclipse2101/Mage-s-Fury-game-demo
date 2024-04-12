using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    public GameObject ScreenOne;
    public GameObject ScreenTwo; 
 

    
    // Start is called before the first frame update
    void OnClick()
    {
        ScreenOne.gameObject.SetActive(false);
        ScreenOne.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
