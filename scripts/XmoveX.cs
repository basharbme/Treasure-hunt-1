using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XmoveX : MonoBehaviour {

	private string leve;
	// Use this for initialization

	public void level(string lev){
	
		leve = lev;
		SceneManager.LoadScene (leve);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
