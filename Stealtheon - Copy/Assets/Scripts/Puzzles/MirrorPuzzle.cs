using UnityEngine;
using System.Collections;

public class MirrorPuzzle : Puzzle {
	public GameObject mirrorA, mirrorB;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (mirrorA.transform.position == -mirrorB.transform.position) {
			CompletePuzzle ();
		}
	}
}
