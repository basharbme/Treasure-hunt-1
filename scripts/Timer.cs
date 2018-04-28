using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public int timeLeft = 90;
	public Text countdownText;
	private bool isdead = false;

	// Use this for initialization
	void Start()
	{
		StartCoroutine("LoseTime");
	}

	// Update is called once per frame
	void Update()
	{
		if (isdead) {
			return;
		}
		countdownText.text = ("" + timeLeft);

		if (timeLeft <= 0)
		{
			StopCoroutine("LoseTime");
			countdownText.text = "Times Up!";
			Death ();
			SceneManager.LoadScene ("GameOver");

		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}

	private void Death()
	{
		isdead = true;
		//GetComponent<Score> ().OnDeath ();
	}
}
