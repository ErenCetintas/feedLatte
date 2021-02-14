using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticle : MonoBehaviour {


	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.5f);
	}
	/*void OnTriggerEnter2D(Collider2D hitInfo){
		Debug.Log (hitInfo.name);
		//if(hitInfo.name=="late")
		Destroy (gameObject, 5f);
	}*/
}
