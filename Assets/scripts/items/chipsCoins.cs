using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chipsCoins : MonoBehaviour {

	public float speed=2;
	public Rigidbody2D rb;
	//public GameObject lovePrefab;

	//public int chipsAddPlayer1;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}
	void Update(){
		
	}
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Debug.Log (hitInfo.name);

		if (hitInfo.gameObject.CompareTag ("player1")) {
			addChipsPlayer1 ();
			Destroy (gameObject);
		}else if (hitInfo.gameObject.CompareTag ("player2")) {
			addChipsPlayer2 ();
			Destroy (gameObject);
		}
	}
	void addChipsPlayer1(){
		scoreManager.chipsPlayer1 +=3;
	}
	void addChipsPlayer2(){
		scoreManager.chipsPlayer2 +=3;
	}


}
