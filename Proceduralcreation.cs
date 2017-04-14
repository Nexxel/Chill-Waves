using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceduralcreation : MonoBehaviour
{
    /*
     * This array contains all the background in this order:
     *  Spring, Summer, Autumn, Winter
     *  The first half of the array is day backgrounds and the second half is night ones
     *  The first element of each season is a relaxed background for a bit more of transition
     */
    public GameObject[] backGrounds;
    public GameObject posEnd; // The position where I eliminate a background
    public float nextOffset = 28.3879f; // The offset of instantiation of the next background
    public GameObject transition1;
    public GameObject transition2;
    public GameObject transition_noche1;
    public GameObject transition_noche2;

    private GameObject boardHolder; // The first background we have instantiated
    private GameObject next = null; // The second background we have instantiated
    private GameObject nextOfNext = null; // The third background we have instantiated

    static int roomGenerated = 0; // The number of rooms generated in a year of game
    public static int counter = 0; // The total number of rooms generated
    public static bool day = false; // If we are playing during the day or not

    private int prevRandom = 0;
    private int thisRandom = 0;
    private int size; // Number of backgrounds we have
    private float initialSpeed;
    public static float speed;
    private Color myColor;
    // This offset has a value of 0 or 1/2 and it indicates if we get Day or night backgrounds.
    private float offset = 0;

    // Use this for initialization
    void Start ()
	{
        // Initiate the initial speed ragarding the difficulty
		if (PlayerPrefsManager.GetDifficulty () == 1) 
		{
			initialSpeed = 0.08f;
			speed = initialSpeed;
		}
        else if (PlayerPrefsManager.GetDifficulty() == 0)
		{
			initialSpeed = 0.14f;
			speed = initialSpeed;
		}
        // Initiate the size
        size = backGrounds.Length;
        // We check if we are playing in the night or in the day
		setDay();
        // Instantiate the first relax background (Spring) andthe two next random ones
       	boardHolder = backGrounds[0+offset];
        boardHolder = Instantiate(boardHolder, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        roomGenerated = 1;
        counter = 1;
        instNext(next);
        instNextOfNext(nextOfNext);
    }

    // Update is called once per frame
    void FixedUpdate ()
	{
        /* Every frame, if we reach the position where we update the background, we check if we have to do
         * the transition day/night and update the referencies.
         */

		if (boardHolder.transform.position.x <= posEnd.transform.position.x) {
			setDay();
            updateBoard(boardHolder, next);
            instNextOfNext(nextOfNext);
        }
    }

    // We instantiate the second background as a random of the Srping
    private void instNext(GameObject next)
    {
      	next = backGrounds[Random.Range(1+offset, size / 8+offset)];
        this.next = Instantiate(next, new Vector3(nextOffset, 0, 0), Quaternion.identity) as GameObject;
        roomGenerated++;
        counter++;
    }
    // We instantiate the next background out of screen
    private void instNextOfNext(GameObject next)
    {
        // Regarding on the speed, we instantiate 10 or 20 backgrounds of each season 
        if (speed < 1f)
        {
            next = procedural(next, 10);
        }
        else
        {
            next = procedural(next, 20);
        }
        this.nextOfNext = Instantiate(next, new Vector3(this.next.transform.position.x + nextOffset, 0, 0), Quaternion.identity) as GameObject;
        roomGenerated++;
        counter++;
    }

    // Destroy the left background and we update the referencies
    private void updateBoard(GameObject boardHolder, GameObject next)
    {
        GameObject.DestroyImmediate(this.boardHolder);
        this.boardHolder = next;
        this.next = nextOfNext;
    }

    private void setDay()
    {
        // We update the day boolean and an offset that we will use to get the backgrounds of the night or the day
        if ((System.DateTime.Now.Hour >= 0 && System.DateTime.Now.Hour < 8) || (System.DateTime.Now.Hour >= 20))
        {
            day = false;
            offset = size/2;
        }
        else
        {
            day = true;
            offset = 0;
        }
    }

    private GameObject procedural (GameObject next, int n)
	{
        // Season transitions
		if (roomGenerated == n || roomGenerated == n * 2 || roomGenerated == n * 3 || roomGenerated == n * 4) {
			if (day) {
				next = transition1;
			} else {
				next = transition_noche1;
			}
		} else if (roomGenerated == n + 1 || roomGenerated == n * 2 + 1 || roomGenerated == n * 3 + 1 || roomGenerated == n * 4 + 1) {
			speed += initialSpeed * 0.125f;
			if (day) {
				next = transition2;
			} else {
				next = transition_noche2;
			}
		}
        /* If we reach the number of backgrounds we have to instantiate of each season and we have done the transitions
        *   we put the relaxed background of the season which is the turn from 
        */
        else if (roomGenerated == n + 2) {
			next = backGrounds [size / 8+ offset];
		} else if (roomGenerated == n * 2 + 2) {
			next = backGrounds [size / 4 + offset];
		} else if (roomGenerated == n * 3 + 2) {
			next = backGrounds [3 * (size / 8)+offset];
		} else if (roomGenerated == n * 4 + 2) {
			roomGenerated = 0;
			next = backGrounds [0+offset];
		}
        // We check the season in which we are and we generate the next random background
        // The while's inside the if's is for being sure that we don't generate two equal backgrounds
        else if (roomGenerated < n + 2) {
			while (prevRandom == thisRandom) {
				thisRandom = Random.Range (1+offset, size / 8+offset);
			}
			next = backGrounds [thisRandom];
		} else if (roomGenerated > n + 2 && roomGenerated < n * 2 + 2) {
			while (prevRandom == thisRandom) {
				thisRandom = Random.Range ((size / 8 +offset)+ 1, size / 4+offset);
			}
			next = backGrounds [thisRandom];
		} else if (roomGenerated > n * 2 + 2 && roomGenerated < n * 3 + 2) {
			while (prevRandom == thisRandom) {
				thisRandom = Random.Range ((size / 4+offset) + 1, (3 * (size / 8))+offset);
			}
			next = backGrounds [thisRandom];
		} else if (roomGenerated > n * 3 + 2 && roomGenerated < n * 4 + 2) {
			while (prevRandom == thisRandom) {
				thisRandom = Random.Range((3 * (size / 8)+offset) + 1, size / 2+offset);
			}
			next = backGrounds[thisRandom];
        }
        prevRandom = thisRandom;
    	return next;
    }
}
