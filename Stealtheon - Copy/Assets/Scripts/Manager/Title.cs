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
		SoundSettings ();
	}
	SoundManager sa;
	protected void SoundSettings(){
		sa = FindObjectOfType<SoundManager> ();
		if (sa == null) {
		}
	}
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Quit ();
		} else if (Input.anyKeyDown) {
			StartCoroutine(NewLevel (4));
		}
	}

	public void Quit ()
	{
		Debug.Break ();
		Application.Quit ();
	}
	//Either advances or resets to title screen (Can be adapted for level selection).
	public static IEnumerator NewLevel (float waitTime = 0, bool nextLevel = true)
	{
		SoundManager.PlaySource (true);
		yield return new WaitForSeconds (waitTime);
		if (nextLevel && ((currentLevel + 1) < SceneManager.sceneCountInBuildSettings)) {
			currentLevel = currentLevel + 1;
		} else {
			currentLevel = 0;
		}
		SceneManager.LoadScene (currentLevel);
	}
}
