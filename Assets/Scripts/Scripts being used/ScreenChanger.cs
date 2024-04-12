using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenChanger : MonoBehaviour
{
    public GameObject ScreenOne;
    public GameObject ScreenTwo; 
    private Button ScreenChanger1;
 

    
    // Start is called before the first frame update
    void Awake()
    {
       ScreenChanger1 = GetComponent<Button>();
       ScreenChanger1.onClick.AddListener(ScreenChange);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenChange()
    {
        ScreenOne.gameObject.SetActive(false);
        ScreenOne.gameObject.SetActive(true);
    }
}
