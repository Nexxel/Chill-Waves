using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaEscena : MonoBehaviour {

    public float TimeToGo;

	// Use this for initialization
	void Start () {
        Invoke("Load", TimeToGo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Load()
    {
        SceneManager.LoadScene("title");
    }
}
