using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chipsThrower : MonoBehaviour {

	public Transform chipsPoint;
	public GameObject chipsPrefab2;
	// Use this for initialization
	void Start () {
		//transform.Rotate (Quaternion.Euler (0.0, 0.0, Random.Range (0.0, 360.0)));
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale <= 1 && Time.timeScale > 0) {
			if (Input.GetButtonDown ("Fire1") && scoreManager.chipsPlayer1 > 0) {
				Shoot ();
			}
		}
	}
	void Shoot(){
		scoreManager.chipsPlayer1 -=1;
		Instantiate (chipsPrefab2, chipsPoint.position, chipsPoint.rotation);
	}
}