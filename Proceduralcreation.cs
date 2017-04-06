using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceduralcreation : MonoBehaviour
{

    public GameObject[] backGrounds;
    public GameObject posEnd;
    public float nextOffset = 28.3879f;
    public GameObject transition1;
    public GameObject transition2;
    public GameObject transition_noche1;
    public GameObject transition_noche2;

    private GameObject boardHolder;
    private GameObject next = null;
    private GameObject nextOfNext = null;

    static int roomGenerated = 0;
    public static int counter = 0;
    public static bool day = false;

    private int prevRandom = 0;
    private int thisRandom = 0;
    private int size;
    private float initialSpeed;
    public static float speed;
    private Color myColor;
    private float offset = 0;

    // Use this for initialization
    void Start ()
	{
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
        size = backGrounds.Length;
		setDay();
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
		if (boardHolder.transform.position.x <= posEnd.transform.position.x) {
			setDay();
            updateBoard(boardHolder, next);
            instNextOfNext(nextOfNext);
        }
    }

    private void instNext(GameObject next)
    {
      	next = backGrounds[Random.Range(1+offset, size / 8+offset)];
        this.next = Instantiate(next, new Vector3(nextOffset, 0, 0), Quaternion.identity) as GameObject;
        roomGenerated++;
        counter++;
    }
    private void instNextOfNext(GameObject next)
    {
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

    private void updateBoard(GameObject boardHolder, GameObject next)
    {
        GameObject.DestroyImmediate(this.boardHolder);
        this.boardHolder = next;
        this.next = nextOfNext;
    }

    private void setDay()
    {
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
		} else if (roomGenerated == n + 2) {
			next = backGrounds [size / 8+ offset];
		} else if (roomGenerated == n * 2 + 2) {
			next = backGrounds [size / 4 + offset];
		} else if (roomGenerated == n * 3 + 2) {
			next = backGrounds [3 * (size / 8)+offset];
		} else if (roomGenerated == n * 4 + 2) {
			roomGenerated = 0;
			next = backGrounds [0+offset];
		} else if (roomGenerated < n + 2) {
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
