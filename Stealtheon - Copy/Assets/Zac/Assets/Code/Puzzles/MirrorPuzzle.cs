using UnityEngine;
using System.Collections;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class MirrorPuzzle : Puzzle {
	public GameObject mirrorA, mirrorB;
	public float allowance = 0.2f;

	void Update () {
		bool mirrorX = (mirrorA.transform.localPosition.x < -mirrorB.transform.localPosition.x + allowance && mirrorA.transform.transform.localPosition.x > mirrorB.transform.localPosition.x - allowance) ? true : false;
		bool mirrorY = (mirrorA.transform.localPosition.y == mirrorB.transform.localPosition.y) ? true : false;
		bool mirrorZ = (Mathf.Round(mirrorA.transform.localPosition.z) == Mathf.Round(mirrorB.transform.localPosition.z)) ? true : false;
		if (mirrorX && mirrorY && mirrorZ) {
			CompletePuzzle ();
			this.enabled = false;;
		} /*else {
			Debug.Log ("A is " + mirrorA.transform.localPosition + " B is " + mirrorB.transform.localPosition);	
			Debug.Log (mirrorA.transform.localPosition - mirrorB.transform.position);
			Debug.Log (mirrorX + " " + mirrorY + " " + mirrorZ);
		}*/
	}
}
