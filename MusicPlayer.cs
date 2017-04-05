using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

static MusicPlayer instance = null; 
	// Use this for initialization
	void Awake (){
		if (instance != null){
			Destroy (gameObject);
			print ("Destroying duplicate music player");
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
}
	
	void Start () {
	
	
	
	}
}
	


