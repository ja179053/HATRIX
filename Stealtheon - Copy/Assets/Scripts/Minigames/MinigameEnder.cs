using UnityEngine;
using System.Collections;

public class MinigameEnder : GameManager {
	public float timeLimit = 30;
	public static bool gameOver = false;
	public GameObject showGameOverUI;
	bool useTime;
	/*enum Minigame{
		timeLimit,
		noTimeLimit
	}*/

	// Use this for initialization
	void Start () {
		showGameOverUI.SetActive (false);	
		useTime = (timeLimit == (int)0) ? false : true;
	}
	void FixedUpdate(){
		if (useTime) {
			timeLimit -= Time.fixedDeltaTime;
			if (timeLimit <= 0) {
				EndGame ();
			}
		}
	}
	void EndGame(){
		gameOver = true;
		showGameOverUI.SetActive (true);
	}
}
