using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//Controls the level loaded from the title screen
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class Title : MonoBehaviour
{	
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		} else if (Input.anyKeyDown) {
			SceneManager.LoadScene (1);
		}
	}
}
