using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect_coins : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.name == "kayaz") {
			other.GetComponent<GetCoins> ().counter++;
			Destroy (gameObject);
		}
	}

}
