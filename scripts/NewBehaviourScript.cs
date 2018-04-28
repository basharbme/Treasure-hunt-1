using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	private Rigidbody rb;
	public float speed = 7;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHoriz = Input.GetAxis ("Horizontal");
		float moveVert = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHoriz, 0f, moveVert);
		rb.AddForce (movement * speed);
	}
}
