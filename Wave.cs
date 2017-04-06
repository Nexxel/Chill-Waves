using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void destroy() {
        Destroy(this.gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.CompareTag("border")) {
            Destroy(this.gameObject);
        }
    }
}
