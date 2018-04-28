using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadAfterTime : MonoBehaviour {

	private float delayBeforeLoading = 120f;
	public string sceneNameToLoad;

	private float timeElapsed;

	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;

		if (timeElapsed > delayBeforeLoading) {

			SceneManager.LoadScene (sceneNameToLoad);

		}

	}
}
