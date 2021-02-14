using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supplyThrower : MonoBehaviour {

	public GameObject[] spawnSupply;
	GameObject lattes;
	public float respawnTime = 5f;
	private Vector2 screenBounds;
	public GameObject pringlesCrack;

	// Use this for initialization
	void Start () {
		//screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(supplyWave());
	}
	private void spawnSupplyThrower(){
		Instantiate (pringlesCrack,transform.position, transform.rotation);
		lattes = spawnSupply [Random.Range (0, spawnSupply.Length)];
		GameObject a = Instantiate(lattes) as GameObject;
		a.transform.position = new Vector2(gameObject.transform.position.x ,gameObject.transform.position.y);
	}
	IEnumerator supplyWave(){
		while(true){
			yield return new WaitForSeconds(respawnTime);
			spawnSupplyThrower();
		}
	}
}
