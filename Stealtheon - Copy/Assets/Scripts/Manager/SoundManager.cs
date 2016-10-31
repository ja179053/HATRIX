using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	//public AudioSource[]
	public AudioClip endLevel;
	static AudioSource aso;
	// Use this for initialization
	void Start () {
		aso = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void PlaySource(bool allSounds = false){
		aso.Play ();
	}
}
