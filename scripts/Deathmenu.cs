using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Deathmenu : MonoBehaviour {

	// Use this for initialization
	public Text scoretext;
	void Start () {
		gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

	}
	public void toggleendmenu (float score)
	{
		gameObject.SetActive (true);
		scoretext.text = ((int)score).ToString ();

	}
	public void Restart()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void tomenue()
	{
		SceneManager.LoadScene ("Menu");
	}
}
