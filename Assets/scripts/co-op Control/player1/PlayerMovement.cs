using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class PlayerMovement : MonoBehaviour
{
	private bool left,right;
	public Animator animator;
	public bool isGrounded = false;
	private Rigidbody2D theRB;
	public float jumpForce = 10f;

    //Important so we can get the correct Controls
    [SerializeField]
    int PlayerID;

    [SerializeField]
    float Speed;

    ControlsManager controlsManager;

    void Start()
    {	
		theRB = GetComponent<Rigidbody2D> ();
        //get the ControlManager in the scene
        controlsManager = FindObjectOfType<ControlsManager>();
		right = true;
    }

    void Update()
    {
		
		//float horizontalMove = Input.GetAxis ("Horizontal") * Speed;

		animator.SetFloat ("Speed",Mathf.Abs(theRB.velocity.x));

		if (Time.timeScale <= 1 && Time.timeScale > 0) {
			/*movement*/
			if (Input.GetKey (controlsManager.GetKey (PlayerID, ControlKeys.LeftKey))) {
				//this.gameObject.GetComponent<Transform>().Translate(Vector2.left * Speed * Time.deltaTime);
				theRB.velocity = new Vector2 (-Speed, theRB.velocity.y);
				TurnLeft (); 
			} else if (Input.GetKey (controlsManager.GetKey (PlayerID, ControlKeys.RightKey))) {
				//this.gameObject.GetComponent<Transform>().Translate(Vector2.right * Speed * Time.deltaTime);
				theRB.velocity = new Vector2 (Speed, theRB.velocity.y);
				TurnRight (); 

			} else {
				theRB.velocity = new Vector2 (0, theRB.velocity.y);
			}
			if (Input.GetKey (controlsManager.GetKey (PlayerID, ControlKeys.Action))) {
				Debug.Log ("" + PlayerID + " Action Fired");
				Jump (); 
			}

		}
	
    }

	/*-----------player turns right left----------*/
	public void TurnLeft(){
		if (left)
			return;
		//transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		transform.Rotate(0f,180f,0f);
		left = true;
		right = false;
	}
	public void TurnRight(){
		if (right)
			return;
		//transform.localScale = new Vector3 (Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		transform.Rotate(0f,180f,0f);
		left = false;
		right = true;
	}
	/*jump controller*/
	void Jump(){
		if (Input.GetKey(controlsManager.GetKey(PlayerID, ControlKeys.Action)) && isGrounded == true) {
			//gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 5f), ForceMode2D.Impulse);
			theRB.velocity = new Vector2 (theRB.velocity.y,jumpForce);
			isGrounded = false;
		}
	}
}
