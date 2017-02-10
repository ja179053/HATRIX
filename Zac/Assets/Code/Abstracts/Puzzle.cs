using UnityEngine;
//Parent script for all puzzles. Controls what happens when a puzzle is completed.
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public abstract class Puzzle : MonoBehaviour
{
	bool completed = false;
	//GameObject to be enabled/disabled.
	public GameObject triggeredObject;

	protected void CompletePuzzle ()
	{
		if (!completed) {
			triggeredObject.SetActive (!triggeredObject.activeSelf);
			completed = true;
		}
	}
}
