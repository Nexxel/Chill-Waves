using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Play_Pause : MonoBehaviour
{

    public Sprite[] sprites;
    public Button home;
    public Button play_pause;
    private bool isPaused;
    private Image myImage;
    // Use this for initialization
    void Start()
    {
        isPaused = false;
        myImage = play_pause.GetComponent<Image>();
        myImage.sprite = sprites[0];
        home.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayAndPause();
        }
    }

    public void PlayAndPause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            home.gameObject.SetActive(true);

            myImage.sprite = sprites[1];
            Time.timeScale = 0.0f;
        }
        else
        {
            
            home.gameObject.SetActive(false);
            myImage.sprite = sprites[0];
            Time.timeScale = 1f;
        }
    }
}
