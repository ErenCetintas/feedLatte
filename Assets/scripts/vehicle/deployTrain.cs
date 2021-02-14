using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployTrain : MonoBehaviour {
	public GameObject spawnTrain;
	GameObject lattes;
	public float respawnTime = 5f;
	private Vector2 screenBounds;

	// Use this for initialization
	void Start () {
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		StartCoroutine(trainWave());
		spawnTrainn ();
	}
	private void spawnTrainn(){
		//lattes = spawnTrain [Random.Range (0, spawnTrain)];
		GameObject a = Instantiate(spawnTrain) as GameObject;
		a.transform.position = new Vector2(screenBounds.x * -1.5f, -2.834f);
	}
	IEnumerator trainWave(){
		while(true){
			yield return new WaitForSeconds(respawnTime);
			spawnTrainn();
		}
	}
}