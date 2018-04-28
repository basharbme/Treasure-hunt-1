using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovementController : MonoBehaviour {
	public bool isGrounded;
	private float speed;
	public float rotSpeed;
	public float jumpHeight;
	//walk speed
	private float w_speed = 0.14f;
	//rotation speed
	private float rot_speed = 3f;
	Rigidbody rb;

	Animator anim;
	public GameObject deathParticles;
	private Vector3 spawn;
	private int Score;
	public Text ScoreText;
	float v; //vertical movements
	float h; //horizontal movements
	float sprint;
	public GameObject menuContainer;
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		isGrounded = true;
		spawn = transform.position;
		Score = 0;
		SetScoreText ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGrounded)
		{
			//moving forward and backward
			if (Input.GetKey(KeyCode.W))
			{
				speed = w_speed;
				movementControl("WalkingForward");
			}
			else if (Input.GetKey(KeyCode.S))
			{
				speed = w_speed;
				movementControl("WalkingBackward");
			}
			else
			{
				movementControl("idle");
			}
			//moving right and left
			if (Input.GetKey(KeyCode.A))
			{
				rotSpeed = rot_speed;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				rotSpeed = rot_speed;
			}
			else
			{
				rotSpeed = 0;
			}
		}
		var z = Input.GetAxis("Vertical") * speed;
		var y = Input.GetAxis("Horizontal") * rotSpeed;
		transform.Translate(0, 0, z);
		transform.Rotate(0, y, 0);
		//jumping function
	/*	if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
		{
			anim.SetTrigger("isJumping");
			rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
			isGrounded = false;
		}*/

		if (transform.position.y < -2) {
			Die ();
		}

	//anim.SetFloat ("Turn", y);


	}
	void movementControl(string state)
	{
		switch (state)
		{
		case "WalkingForward":
			anim.SetBool("isWalkingForward", true);
			anim.SetBool("isWalkingBackward", false);
			anim.SetBool("isIdle", false);
			break;
		case "WalkingBackward":
			anim.SetBool("isWalkingForward", false);
			anim.SetBool("isWalkingBackward", true);
			anim.SetBool("isIdle", false);
			break;
		case "idle":
			anim.SetBool("isWalkingForward", false);
			anim.SetBool("isWalkingBackward", false);
			anim.SetBool("isIdle", true);
			break;
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Enemy") {
			//Die ();
			//menuContainer.SetActive (true);
		}

	}

	void Die(){
		Instantiate (deathParticles, transform.position, Quaternion.Euler(270,0,0));
		transform.position = spawn;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Cocount")){
			other.gameObject.SetActive (false);
			Score = Score + 1;
			SetScoreText ();
	}
	}
		void SetScoreText(){
		ScoreText.text = "Score: " + Score.ToString ();
		}
}
