using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    private AudioSource audio;
    public AudioClip[] drops;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        AudioClip sound = drops[ (int) Random.Range(0, drops.Length)];
        audio.clip = sound;
        audio.Play();
        Invoke("kill", 5f);
	}

    void kill() {
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
