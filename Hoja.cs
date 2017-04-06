using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hoja : MonoBehaviour {

    public Camera cam;
    public int lifes;
    public float maxDist;
    public float speed;
    public LifesPannel lifesPanel;
    public Sprite[] characterSprites;
    public float maxSpeed;
    public GameObject drop;
    public AudioClip [] sounds;

    private AudioSource mySource;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private bool isInvencible;
    private SpriteRenderer mySprite;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        mySource = GetComponent<AudioSource>();
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.sprite = characterSprites[PlayerPrefsManager.GetCharacter()];
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRigidbody.drag = 0.5f;

        InvokeRepeating("moveLeaf", 0.01f, 0.4f);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            moveLeaf();
        }
	}


    void moveLeaf() {
        if (Input.GetMouseButton(0) && Time.timeScale != 0)
        {
            Vector3 tapPos = CalculateWorldPointOfMouseClick();
            Vector2 distance = new Vector2(transform.position.x - tapPos.x, transform.position.y - tapPos.y);
            AddForce(distance.normalized, Mathf.Max(0, maxDist - distance.magnitude));
        }
    }
    Vector2 CalculateWorldPointOfMouseClick() {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 5f;         //We don't use it! :D

        Vector3 mouseClickPos = new Vector3(mouseX, mouseY, distanceFromCamera);
        
        Vector2 worldPos = cam.ScreenToWorldPoint(mouseClickPos);
             Instantiate(drop, worldPos, Quaternion.identity);
        
        return worldPos;
    }
     

    public void AddForce(Vector2 force, float module) {
        myRigidbody.AddForce(force*module*speed); 
        if (myRigidbody.velocity.magnitude > maxSpeed) {
            myRigidbody.velocity = myRigidbody.velocity.normalized * maxSpeed;
        }
    }

    public void toggleInvencible() {
        isInvencible = false;
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Obstacle")) {
            if (!isInvencible) {
                isInvencible = true;
                myAnimator.SetTrigger("damaged");
                mySource.clip = sounds[0];
                mySource.Play();
                lifes--;
                if (col.gameObject.name == "Ju-on") {
                    lifes = 0;
                    //Add here Ju-on's gameover screen
                }
                if (lifes <= 0) {
                    SceneManager.LoadScene("Perder");
                }
                lifesPanel.updateLifes(lifes);
            }
        }else if (col.CompareTag("Fly")) {
            lifes++;
            lifes = Mathf.Min(3, lifes);
            lifesPanel.updateLifes(lifes);
            mySource.clip = sounds[1];
            mySource.Play();
            Destroy(col.gameObject);
        }
    }
}
