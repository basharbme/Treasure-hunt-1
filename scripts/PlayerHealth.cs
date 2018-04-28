using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public Slider healthBar;
	public Text healthText;
	public GameObject menuContainer;

	float maxHealth=100;
	float curHealth;
	private bool isdead = false;
	// Use this for initialization
	void Start () {
		healthBar.value = maxHealth;
		curHealth = healthBar.value;
	}
	
	// Update is called once per frame
	void Update () {
		if (isdead) {
			return;
		}
		healthText.text = curHealth.ToString () + " %";
		if (healthBar.value == 0) {
			Death ();
			SceneManager.LoadScene ("GameOver");

		}

	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy") {
			healthBar.value -= 5f;
			curHealth = healthBar.value;

		}
			
	}


	private void Death()
	{
		isdead = true;
		//GetComponent<Score> ().OnDeath ();
	}

}
