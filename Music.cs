using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {


	static Music song = null;
	
	
	void Awake(){
		
		if(song != null){
			Destroy (gameObject);
		}
		
		else{
			GameObject.DontDestroyOnLoad(gameObject);
			song=this;


		}
	}

	void Update(){


		if(Application.loadedLevel == 3){
				Destroy (gameObject);
			}

	}


}
