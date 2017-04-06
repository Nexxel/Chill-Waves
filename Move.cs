using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static float score = 0;


    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0) {

            transform.position += new Vector3(-Proceduralcreation.speed, 0, 0);
			score += Proceduralcreation.speed / 2;

        }
    }
}
