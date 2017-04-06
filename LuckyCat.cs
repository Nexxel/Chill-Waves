using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCat : MonoBehaviour {

    public float xDist, yDist;              // The range of the wave
    [Tooltip("Power of the wave")]
    public float power;
    private Hoja player;
	
    // Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Hoja>();
        if (player == null) {
            Debug.LogError("Couldn't find any player in the scene!");
        }
    }

    public void ProduceWave() {
        float thisX = this.transform.position.x;
        float thisY = this.transform.position.y;
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        Debug.Log(Mathf.Max((thisX - playerX), 0));
        if ((thisX - playerX) <= xDist && (thisX - playerX) > 0) {                   // Is the player in range? (The max between that number and zero is to prevent pushing from the back)
            if (Mathf.Abs(thisY - playerY) < yDist) {

            Vector2 push = new Vector2(playerX - thisX, playerY - thisY);
            player.AddForce(push.normalized, push.magnitude*power);
            }

        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
