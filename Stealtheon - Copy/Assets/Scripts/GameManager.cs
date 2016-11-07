using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static bool paused;
	static Canvas pauseScreen;
	static AudioSource[] sounds;
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
		pauseScreen.enabled = false;
	}
	public void Resume(){
		Paused = false;
	}
	public void Quit(){
		Debug.Break ();
		Application.Quit ();
	}
}
