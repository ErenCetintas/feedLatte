using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployLatte : MonoBehaviour {
	public GameObject[] spawnFlyLatte;
	GameObject lattes;
	public float respawnTime = 5f;
	private Vector2 screenBounds;

	// Use this for initialization
	void Start () {
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(latteWave());
	}
	private void spawnLattee(){
		lattes = spawnFlyLatte [Random.Range (0, spawnFlyLatte.Length)];
		GameObject a = Instantiate(lattes) as GameObject;
		a.transform.position = new Vector2(screenBounds.x * -1.3f, Random.Range(-screenBounds.y +4.5f, screenBounds.y-3f));
	}
	IEnumerator latteWave(){
		while(true){
			yield return new WaitForSeconds(respawnTime);
			spawnLattee();
		}
	}
}