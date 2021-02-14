using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManager : MonoBehaviour {
	 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D hitInfo){
		Debug.Log (hitInfo.name);

		if (hitInfo.name == "eren") {
			//Instantiate (lovePrefab, transform.position, transform.rotation);
			Destroy (gameObject);
		}
		else if((hitInfo.name == "ege")){
			Destroy (gameObject);
		}
	}
}
