using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenChanger : MonoBehaviour
{
    public GameObject ScreenOne;
    public GameObject ScreenTwo; 
    private Button ScreenChanger1;
    public TextMeshProUGUI ScreenUno;
    public TextMeshProUGUI ScreenDuo;
    public bool isButtonWorking = true;
    private AudioSource buttonSound;
    public AudioClip errorSound;
    public AudioClip selectSound;

    
    // Start is called before the first frame update
    void Awake()
    {
       ScreenChanger1 = GetComponent<Button>();
       ScreenChanger1.onClick.AddListener(ScreenChange);
        
    }

    void Start()
    {
        buttonSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScreenChange()
    {
        if (isButtonWorking == true)
        {
         ScreenDuo.gameObject.SetActive(true);
         ScreenUno.gameObject.SetActive(false);
         //buttonSound.PlayOneShot(selectSound, 1.5f);
        }
        else
        {
           buttonSound.PlayOneShot(errorSound, 1.5f); 
        }
    
        /*
        ScreenOne.gameObject.SetActive(false);
        ScreenOne.gameObject.SetActive(true);
        */
    }
}
