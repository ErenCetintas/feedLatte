using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chips1 : MonoBehaviour {
	public float speed=8;
	public Rigidbody2D rb;
	public GameObject lovePrefab;
	public GameObject chipsCrack;
	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}
	void OnTriggerEnter2D(Collider2D hitInfo){
		Debug.Log (hitInfo.name);

		if (hitInfo.gameObject.CompareTag ("lattePlane")) {
			Instantiate (lovePrefab, transform.position, transform.rotation);
			scoreManager.timeLeft +=0.25f;
			scoreManager.scorePlayer1 += 10;
			Destroy (gameObject);
		}else if (hitInfo.gameObject.CompareTag ("latteBaloon")) {
			Instantiate (lovePrefab, transform.position, transform.rotation);
			scoreManager.timeLeft +=0.1f;
			scoreManager.scorePlayer1 += 7;
			Destroy (gameObject);
		}else if (hitInfo.gameObject.CompareTag ("latteRun")) {
			Instantiate (lovePrefab, transform.position, transform.rotation);
			scoreManager.timeLeft +=0.2f;
			scoreManager.scorePlayer1 += 5;
			Destroy (gameObject);
		}else if (hitInfo.gameObject.CompareTag ("Ground")) {
			Instantiate (chipsCrack, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}
	

}
