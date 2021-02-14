using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chipsThrower2 : MonoBehaviour {

	public Transform chipsPoint;
	public GameObject chipsPrefab2;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale <= 1 && Time.timeScale > 0) {
			if (Input.GetButtonDown ("Fire2") && scoreManager.chipsPlayer2 > 0) {
				Shoot ();
			}
		}
	}
	void Shoot(){
		scoreManager.chipsPlayer2 -=1;
		Instantiate (chipsPrefab2, chipsPoint.position, chipsPoint.rotation);
	}
}