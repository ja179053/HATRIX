using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		} else if (Input.anyKeyDown) {
			SceneManager.LoadScene (1);
		}
	}
}
