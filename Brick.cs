using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

public AudioClip BlockCrack;
public LevelManager levelManager;
private int maxHits;
public Sprite [] hitSprites;

private int timesHit;
public static int breakableCount = 0; 
private bool isBreakable;
public GameObject smoke;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keeps track of breakable bricks
		if (isBreakable){
			breakableCount++;
			Debug.Log (breakableCount);
			}
		
		timesHit = 0;				
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void  OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (BlockCrack, transform.position); 
		if (isBreakable){
		HandleHits ();
		}
	}
	
	void HandleHits(){
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if (timesHit >= maxHits) {
		breakableCount--;
        Destroy(gameObject);
       
        levelManager.BrickDestroyed();
		Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		
		
		}
		else {
		LoadSprites();
		}
	}
		
		void LoadSprites (){
			int spriteIndex = timesHit -1;
			if (hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
			} else {
				Debug.LogError ("Bricks with sprites missing");
			}
	}
		
	
		
	void SimulateWin () {
		levelManager.LoadNextLevel();
		}
	
}
