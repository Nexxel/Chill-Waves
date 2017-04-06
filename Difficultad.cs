using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficultad : MonoBehaviour {
    private GameObject Butref;
    private Image im;
    private Color myColor;
    public Sprite HardOn;
    public Sprite HardOff;
    public Sprite EasyOn;
    public Sprite EasyOff;


    public void SetDifucultadEasy(){
        PlayerPrefsManager.SetDifficulty(1);
        Butref = GameObject.Find("Button3");
        im = Butref.GetComponent<Image>();
        myColor = im.color;
        myColor.a = 1f;
        im.color = myColor;
    }

    public void SetDifucultadHard()
    {
        PlayerPrefsManager.SetDifficulty(0);
        Butref = GameObject.Find("Button4");
        im = Butref.GetComponent<Image>();
        myColor = im.color;
        myColor.a = 1f;
        im.color = myColor;
    }


    void Update()
    {

        if (PlayerPrefsManager.GetDifficulty() != 0)
        {
            Butref = GameObject.Find("Button4");
            im = Butref.GetComponent<Image>();
            im.sprite = HardOff;

            Butref = GameObject.Find("Button3");
            im = Butref.GetComponent<Image>();
            im.sprite = EasyOn;

        }

        if (PlayerPrefsManager.GetDifficulty() != 1)
        {
            Butref = GameObject.Find("Button3");
            im = Butref.GetComponent<Image>();
            im.sprite = EasyOff;

            Butref = GameObject.Find("Button4");
            im = Butref.GetComponent<Image>();
            im.sprite = HardOn;


        }
    }




}
   

