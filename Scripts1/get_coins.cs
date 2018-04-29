using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;

public class get_coins : MonoBehaviour
{
   //this script is used to detect the collision of tank and update score and time
//must be attached to the tank to detect various collisions and effecting score in the same manner



	public int score=0;
	public Text scoreText;
	public Text winScore;
	public float timeRemaining=356;
	public Text timeText;
	private int min=0;
	private int sec=0;
	public AudioClip StarHitSound;
	public AudioSource audio1;
	public GameObject firework;
	public GameObject GameWin;
	public GameObject GameOver;
	public bool ClockStop=false;
	public bool loss=false;
	void Start()
	{
		SetCountText();
		SetTime();
	}
	void Update()
	{
		if(timeRemaining>0.0f && !ClockStop)
		{
		timeRemaining-=Time.deltaTime;
		SetTime();
		}
		SetCountText();
		if((loss==true || timeRemaining<=0.0f) && !GameOver.activeSelf)
		{
			GameOver.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").
                GetComponent<MovementController>().enabled = false;
						ClockStop=true;

		}

	}
	void OnTriggerEnter(Collider other) 
	{
		//for increasing score on collecting stars and destroying star
		if (other.gameObject.CompareTag ("star"))
		{
			score=score+25;
			audio1.PlayOneShot(StarHitSound);
			//other.gameObject.SetActive(false);
			Destroy(other.gameObject);
            //if (score == 255)
            //{

            //}
            Debug.Log(score);
		}
		// for increasing the time by 1 mi on colliding with clock
		else if (other.gameObject.CompareTag ("SandClock"))
		{
			timeRemaining+=60;
			audio1.PlayOneShot(StarHitSound);
			//other.gameObject.SetActive(false);
			Destroy(other.gameObject);
		}
		//for wining fireworks
		else if (other.gameObject.CompareTag ("SilverCup") && !GameWin.activeSelf)
		{
			firework.SetActive(true);
			score+=250;
			ClockStop=true;
			GameWin.SetActive(true);
			GameObject.FindGameObjectWithTag("Player").
                GetComponent<MovementController>().enabled = true;
           
			winScore.text="Your Score: "+score.ToString(); 

		}
		SetCountText();
	}
	void SetCountText ()
	{
		scoreText.text = "Score: " + score.ToString ();

	}
	void SetTime()
	{
		min=(int)timeRemaining/60;
		sec=(int)timeRemaining%60;
		string niceTime = string.Format("{0:00}:{1:00}", min, sec);
	
		timeText.text=niceTime;
	}
	public void increaseScore(int num)
	{
		score+=num;
		audio1.PlayOneShot(StarHitSound);
	}
}
