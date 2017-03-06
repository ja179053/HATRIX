using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Score : MonoBehaviour {
//	Attach to a text in the scene called score. Will auto-update during minigames
	Text scoreText;
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score :" + MinigameHead.score;	
	}
}
