using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//Controls the level loaded. Exits on scene 0.
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class Title : MonoBehaviour
{
	protected static int currentLevel = 0;
	void Start(){
		currentLevel = 0;
	}
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		} else if (Input.anyKeyDown) {
			NewLevel ();
		}
	}
	//Either advances or resets to title screen (Can be adapted for level selection).
	public static void NewLevel (bool nextLevel = true)
	{
		if (nextLevel && ((currentLevel + 1) < SceneManager.sceneCountInBuildSettings)) {
			currentLevel = currentLevel + 1;
		} else {
			currentLevel = 0;
		}
		SceneManager.LoadScene (currentLevel);
	}
}
