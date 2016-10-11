using UnityEngine;
using System.Collections;

public abstract class Puzzle : MonoBehaviour {
	bool completed = false;
	public GameObject triggeredObject;

	protected void CompletePuzzle(){
		if (!completed) {
			triggeredObject.SetActive (!triggeredObject.activeSelf);
			completed = true;
		}
	}
}
