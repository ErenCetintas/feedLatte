using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnchipsThrower : MonoBehaviour {

	public float respawnTime = 5f;
	public float speed=5;

	public Transform chipsPoint;
	public GameObject chipsPrefab;
	public GameObject pringlesCrack;

	public Rigidbody2D rb;
	void Start (){
		StartCoroutine(spawnWave());
		rb.velocity = transform.up * speed;
	}

	private void spawnSupplyChips(){
		Instantiate (chipsPrefab, chipsPoint.position, chipsPoint.rotation);
		Instantiate (pringlesCrack, chipsPoint.position, chipsPoint.rotation);
		Destroy (this.gameObject, 7);

	}

	IEnumerator spawnWave(){
		while(true){
			yield return new WaitForSeconds(respawnTime);
			spawnSupplyChips();
		}
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		if (hitInfo.gameObject.CompareTag ("player1")) {
			addChipsPlayer1 ();
			Destroy (gameObject);
		}else if (hitInfo.gameObject.CompareTag ("player2")) {
			addChipsPlayer2 ();
			Destroy (gameObject);
		}
	}
	void addChipsPlayer1(){
		scoreManager.chipsPlayer1 +=5;
	}
	void addChipsPlayer2(){
		scoreManager.chipsPlayer2 +=5;
	}
}