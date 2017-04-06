using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesPannel : MonoBehaviour {

    public Sprite[] sprites;

    private SpriteRenderer mySprite;
	// Use this for initialization
	void Start () {
        mySprite = GetComponent<SpriteRenderer>();
	}

    public void updateLifes(int index) {
        mySprite.sprite = sprites[index];
    }
    	
	// Update is called once per frame
	void Update () {
		
	}
}
