using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night : MonoBehaviour
{

    public SpriteRenderer shadow;

    private Color myColor;
    private bool isDay;

    void Start()
    {
        // At first, we check the time in which we are playing
        myColor = shadow.color;
        if ((System.DateTime.Now.Hour >= 0 && System.DateTime.Now.Hour < 8) || (System.DateTime.Now.Hour >= 20))
        {
            isDay = false;
        }
        else
        {
            isDay = true;
        }
        // We set the shadow transparency (To simulate a bit more the day or the night)
        if (isDay)
        {
            myColor = shadow.color;
            myColor.a = 0;
            shadow.color = myColor;
        }
        else
        {
            myColor = shadow.color;
            myColor.a = 1;
            shadow.color = myColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If we have passed from day to night or night to day, put or take off the transparency gradually
        if (!this.isDay.Equals(Proceduralcreation.day))
        {
            if (Proceduralcreation.day)
            {
                myColor = shadow.color;
                myColor.a -= 0.01f;
                shadow.color = myColor;
                if (shadow.color.a <= 0)
                {
                    this.isDay = true;
                }
            }
            else
            {
                myColor = shadow.color;
                myColor.a += 0.01f;
                shadow.color = myColor;
                if (shadow.color.a >= 1)
                {
                    this.isDay = false;
                }
            }
        }
    }
}
