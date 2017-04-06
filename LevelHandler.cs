using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {

    public void LoadScene(string scene) {

        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

	public void LoadSceneAndReset(string scene) {
		Move.score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
    }

    public void exitGame() {
        Application.Quit();
    }
}
