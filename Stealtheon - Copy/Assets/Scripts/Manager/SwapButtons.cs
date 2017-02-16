using UnityEngine;
using System.Collections;

public class SwapButtons : MonoBehaviour {
	public GameObject normalButtons, levelButtons;
	// Use this for initialization
	void Start () {
		if (normalButtons == null || levelButtons == null) {
			normalButtons = GameObject.Find ("NormalButtons");
			levelButtons = GameObject.Find ("LevelButtons");
		}
		normalButtons.SetActive (true);
		levelButtons.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SwapLevels(){
		normalButtons.SetActive (!normalButtons.activeSelf);
		levelButtons.SetActive (!normalButtons.activeSelf);
	}
}
