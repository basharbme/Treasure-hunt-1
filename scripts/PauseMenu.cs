using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
	Animator anim;


	// Use this for initialization
	void Start () {
		//anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		
		}
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		anim.SetBool("isWalkingForward", false);
		anim.SetBool("isWalkingBackward", false);
		anim.SetBool("isIdle", false);
	}


	public void LoadMenu(){
		SceneManager.LoadScene ("StartMenu");

	}

	public void QuitGame(){
		SceneManager.LoadScene ("IntroVideo");

	}
}
