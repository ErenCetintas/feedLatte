using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour { 

	Image timerBar;
	public float maxTime=5f;
	public static float timeLeft=5f;
	//public GameObject GameEnd;


	public Text chipsPlayer1Text;
	public Text chipsPlayer2Text;
	public static int chipsPlayer1 = 15;
	public static int chipsPlayer2 = 15;

	public static int scorePlayer1=0;
	public static int scorePlayer2=0;
	public Text scorePlayer1Text;
	public Text scorePlayer2Text;

	public GameObject endGameCanvas;
	public Text playerWonText;

	public Text readyCountText;

	private Animator endGameAnim;

	void Awake(){
		//endgame canvas
		endGameAnim = endGameCanvas.gameObject.GetComponent<Animator>();
		endGameAnim.enabled=false;
		endGameCanvas.SetActive (false);
			
		//time inactivate at start
		Time.timeScale = 0;
	}
	void Start()
	{ 	
		//readycountdowner parameters
		StartCoroutine(Countdown(3));
		readyCountText.gameObject.SetActive (true);
	}
	//readycountdowner
	public IEnumerator Countdown(int seconds)
	{
		float count = seconds;

		while (count > 0) {

			if (count > 0) {
				readyCountText.text = "" + Mathf.RoundToInt (count);
			} else if (count == 0) {
				readyCountText.text = "GO!";
			}

			yield return null;
			count -= Mathf.Clamp(Time.unscaledDeltaTime,0f, 0.3f);
		}
		// count down is finished...
		StartGame();
	}


	void StartGame()
	{	
		//time activate
		Time.timeScale = 1;

		//ready counter text
		readyCountText.gameObject.SetActive (false);

		//timerbar
		timerBar = GetComponent<Image> ();
		timeLeft = maxTime;
	}
		

	void Update () {
		//set chipses
		chipsPlayer1Text.text = "" + chipsPlayer1;
		chipsPlayer2Text.text = "" + chipsPlayer2;

		//set scores
		scorePlayer1Text.text = "" + scorePlayer1;
		scorePlayer2Text.text = "" + scorePlayer2;

		//latte timer
		if (timeLeft > 0) {
			timeLeft -= (Time.deltaTime*0.4f);
			timerBar.fillAmount = timeLeft / maxTime;
		} else if(timeLeft < 0 ) {
			
			//slow mo effect -- game end
			do{
				Time.timeScale -= (Time.deltaTime*0.8f);
				Debug.Log(Time.timeScale);
			

			}while(Time.timeScale==0.1f);

			//game over controller
			if (Time.timeScale < 0.1f) {
				endGameCalculations ();
				Debug.Log("zaman durdu");
			}
		}
		//set max time 
		if (timeLeft > 5) {
			timeLeft = 5;
		}
			
	}

	void endGameCalculations(){
		endGameCanvas.SetActive (true);
		endGameAnim.enabled=true;
		scorePlayer1Text.text = "" + scorePlayer1;
		scorePlayer2Text.text = "" + scorePlayer2;
		if (scorePlayer1 > scorePlayer2) {
			playerWonText.text="PLAYER 1 WON!";
			//Debug.Log ("Player1 won");
		} else if (scorePlayer2 > scorePlayer1) {
			playerWonText.text="PLAYER 2 WON!";
			//Debug.Log ("Player2 won");
		} else {
			playerWonText.text="TIE GAME!";
			//Debug.Log ("tie game");
		}
		Time.timeScale = 0;
	}

	//restart button
	public void playAgainButton(){
		SceneManager.LoadScene ("ingame");
	}


}
