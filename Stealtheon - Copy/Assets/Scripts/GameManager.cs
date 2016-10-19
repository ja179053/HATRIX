using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static bool paused, options;
	static Canvas pauseScreen;
	static AudioSource[] sounds;
	static Button[] defaultButtons;
	public GameObject optionsMenu;
	public static bool Paused{
		get{
			return paused;
		} set {
			paused = value;
			if (paused) {
				foreach (AudioSource aso in sounds) {
					aso.Pause ();
				}
				Time.timeScale = 0;
				UpdateIcon ();
			} else {
				foreach (AudioSource aso in sounds) {
					aso.UnPause (); 
				}
				Time.timeScale = 1;
			}
			pauseScreen.enabled = paused;
		}
	}
	void Start(){
		pauseScreen = FindObjectOfType<Canvas> ();
		sounds = FindObjectsOfType<AudioSource> ();
		defaultButtons = FindObjectsOfType<Button> ();
		pauseScreen.enabled = false;
	}
	public void Resume(){
		Paused = false;
	}
	public void Quit(){
		Debug.Break ();
		Application.Quit ();
	}
	public void Options(){
		foreach (Button b in defaultButtons) {
			b.gameObject.SetActive (optionsMenu.activeSelf);
		}
		optionsMenu.SetActive (!optionsMenu.activeSelf);
	}
	static Button[] activeButtons;
	public Image icon;
	static void UpdateIcon(){
		activeButtons = FindObjectsOfType<Button> ();
		//icon.rectTransform = activeButtons[0].
	}
}
