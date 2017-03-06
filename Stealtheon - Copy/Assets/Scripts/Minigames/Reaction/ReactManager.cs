using UnityEngine;
using System.Collections;

public class ReactManager : MinigameHead {
	public GameObject identifyObject1, identifyObject2;
	GameObject current;
	// Use this for initialization
	void Start () {
		score = 0;
		Go ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!MinigameEnder.gameOver) {
			if (Input.GetKeyDown (KeyCode.L)) {
				//	Skip ();
				Score (identifyObject1);
			} else if (Input.GetKeyDown (KeyCode.K)) {
				//	Stamp ();
				Score (identifyObject2);
			}
		}
	}
	void Score(GameObject g){
		score += (current.name == g.name + "(Clone)") ? 1 : -1;
		Go ();
	}
	void Go(){	
		if (current != null) {	
			Destroy (current);
		}
		current = Instantiate (RandomGameobject(), transform.position, Quaternion.identity) as GameObject;
	}
	GameObject RandomGameobject(){
		int i = Random.Range (0, 2);
		if (i == 0) {
			return identifyObject1;			
		} 
		return identifyObject2;
	}

}
