using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetCoins : MonoBehaviour {

	public int counter = 0;
	public AudioSource aud;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*if (counter == 4) {
			SceneManager.LoadScene ("GameOver");

		}*/
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		GUI.Label(new Rect(10,10,100,20), "score : " + counter);
		aud.Play ();
	
	}
}
