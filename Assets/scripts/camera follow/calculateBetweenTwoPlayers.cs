using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculateBetweenTwoPlayers : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	void Start () {
		
	}

	void Update () {
		//float distance = Vector3.Distance (player1.transform.position, player2.transform.position);
		//distance/=2;
		Vector3 midPoint = (player1.transform.position + player2.transform.position) * 0.5f;
		if (this.transform.position.x >= -1 && this.transform.position.x <= 1) {
			this.transform.position = midPoint;
		}
		if (this.transform.position.x < -1) {
			this.transform.position = new Vector3 (-1f, -3.32f, transform.position.z);
		} 
		if (this.transform.position.x > 1) {
			this.transform.position = new Vector3 (1f, -3.32f, transform.position.z);
		}
		this.transform.position = new Vector3(transform.position.x, -3.32f, transform.position.z);



	}
}
