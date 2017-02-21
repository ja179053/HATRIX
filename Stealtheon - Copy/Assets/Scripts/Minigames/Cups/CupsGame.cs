using UnityEngine;
using System.Collections;

public class CupsGame : Singleton<CupsGame> {
	public static Cup[] cups;
	static int ballNum, difficulty = 3;
	public static int Difficulty{
		get{ return difficulty; } set {
			difficulty = value;	
			Restart (difficulty);
		}
	}
	public static GameObject ball;
	public static bool running = false;
	// Use this for initialization
	void Start () {
		if (ball == null) {
			ball = GameObject.Find ("Ball");
		}
		cups = FindObjectsOfType<Cup> ();
		Restart (difficulty);
	}
	public static void Restart(int times){
		running = true;
		Instance.StartCoroutine(MoveBall (times));
	}
	public static IEnumerator Swap(int times){
		int i = Random.Range (0, 3);
		int i2 = i;
		while (i2 == i) {
			i2 = Random.Range (0, 3);
		}
		Vector3 tempPos = cups [i].transform.position;
		cups[i].Swap(cups[i2].transform.position);
		cups [i2].Swap (tempPos);
		yield return new WaitForSeconds (5 / difficulty);
		if (times > 1) {
			Instance.StartCoroutine(Swap(times - 1));
			yield break;
		}
		running = false;
	}
	static IEnumerator MoveBall(int times){
		ballNum = Random.Range (0, 3);
		ball.transform.parent = cups [ballNum].transform;
		ball.transform.localPosition = Vector3.zero;
		ball.transform.parent = Instance.transform;
		Instance.StartCoroutine(cups [ballNum].Reveal());
		yield return new WaitForSeconds (5);
		ball.transform.parent = cups [ballNum].transform;
		Instance.StartCoroutine (Swap (times));
	}
	public static void DecideWin(Cup cup){
		if (cups [ballNum] == cup) {
			Debug.Log ("You win");
			Difficulty++;
		} else {
			Debug.Log ("You lose");
			Difficulty--;
		}
	}
}
