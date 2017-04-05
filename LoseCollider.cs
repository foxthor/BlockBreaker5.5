using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
private LevelManager levelManager;
public int lifeCount;
public static int lifeShown;
public LifeCount life;
private Ball ball;
     
	
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
		
	}

    void OnTriggerEnter2D(Collider2D trigger) {
            lifeCount = lifeCount - 1;
            Debug.Log("lifeCount = " + lifeCount);
            lifeShown = lifeShown + 1;
            Debug.Log("lifeShown =" + lifeShown);
            ball.transform.position = new Vector3(13f, 11f, 0f);

        if (lifeCount <= 0)        {
            levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("LoseScreen");
        }
            loadLifeSprite();
                  
}

   void loadLifeSprite() {
            life.gameObject.GetComponent<SpriteRenderer>().sprite = life.lifeSprites[lifeShown];

    }

	// Use this for initialization
	void Start () {
            lifeCount = 3;
            lifeShown = -1;
            print("LifeCount = 3");
            ball = GameObject.FindObjectOfType<Ball>();
            life = GameObject.FindObjectOfType<LifeCount>();
    
    }
	
	// Update is called once per frame
	void Update () {
	       
	}
}
