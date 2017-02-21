using UnityEngine;
using System.Collections;

public class Cup : MonoBehaviour {
	Vector3 newPos;
	// Use this for initialization
	void Start () {
		newPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (newPos != null) {
			transform.position = Vector3.MoveTowards (transform.position, newPos, Time.deltaTime * CupsGame.Difficulty * 2);	
		}
	}
	public void Swap(Vector3 destination){
	//	Debug.Log (destination + this.name);
		newPos = destination;
	//	MoveTo (destination);
	//	StartCoroutine (MoveTo (destination));
	//	transform.position = newPos;
	}
	public IEnumerator Reveal(){
		transform.position += (Vector3.up * 5);
		newPos = transform.position;
		yield return new WaitForSeconds (4);
		transform.position += (Vector3.up * -5);
		newPos = transform.position;
	}

	void MoveTo(Vector3 destination){
		if (transform.position == destination) {
			transform.position = Vector3.MoveTowards (transform.position, destination, Time.deltaTime * CupsGame.Difficulty * 2);	
		} else {
			MoveTo (destination);
		}
	}
	void OnMouseDown(){
		if (!CupsGame.running) {
			//Show ();
			CupsGame.DecideWin(this);
		}
	}
}
