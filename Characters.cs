using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Characters : MonoBehaviour
{
    private GameObject Butref;
    private Image im;
    private Color myColor;
    private Image ImVol;
    private float vol = 0;

    private Slider mySlider;

    void Start()
    {
        mySlider = FindObjectOfType<Slider>();
		mySlider.maxValue = 3;

        if (PlayerPrefsManager.GetVolume() == 0f)
        {
            mySlider.value = 0;
        }
        if (PlayerPrefsManager.GetVolume() == 0.2f)
        {
            mySlider.value = 1;
        }
        if (PlayerPrefsManager.GetVolume() == 0.465f)
        {
            mySlider.value = 2;
        }
        if (PlayerPrefsManager.GetVolume() == 0.87f)
        {
            mySlider.value = 3;
        }

    }


    public void Character0()
    {
        PlayerPrefsManager.SetCharacter(0);
        Butref = GameObject.Find("Button0");
        im = Butref.GetComponent<Image>();
        myColor = im.color;
        myColor.a = 1f;
        im.color = myColor;
    }

    public void Character1()
    {
        PlayerPrefsManager.SetCharacter(1);
        Butref = GameObject.Find("Button1");
        im = Butref.GetComponent<Image>();
        myColor = im.color;
        myColor.a = 1f;
        im.color = myColor;
    }



    void Update()
    {
        
        vol = mySlider.value;
        ImVol = mySlider.GetComponentInChildren<Image>();

        if (vol == 0)
        {
            ImVol.fillAmount = 0f;
        }
        else if (vol == 1)
        {
            ImVol.fillAmount = 0.2f;
        }
        else if (vol == 2)
        {
            ImVol.fillAmount = 0.465f;
        }
        else if (vol == 3)
        {
            ImVol.fillAmount = 0.87f;
        }
        PlayerPrefsManager.SetVolume(ImVol.fillAmount);





        if (PlayerPrefsManager.GetCharacter() != 0)
        {
            Butref = GameObject.Find("Button0");
            im = Butref.GetComponent<Image>();
            myColor = im.color;
            myColor.a = 0.5f;
            im.color = myColor;
        }

        if (PlayerPrefsManager.GetCharacter() != 1)
        {
            Butref = GameObject.Find("Button1");
            im = Butref.GetComponent<Image>();
            myColor = im.color;
            myColor.a = 0.5f;
            im.color = myColor;
        }



    }
}
