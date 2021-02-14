using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInside : MonoBehaviour {

	public GameObject cameraFollowingThis;
	// Update is called once per frame
	void Update () {
		Vector3 cam = cameraFollowingThis.transform.position;
		Debug.Log (cam);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, cam.x-8.5f, cam.x+8.4f),
            Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
	}
}
