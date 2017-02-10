using UnityEngine;
using UnityEngine.Audio;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class SoundManager : MonoBehaviour {
	//public AudioSource[]
	public AudioClip endLevel;
	static AudioSource[] sounds;
	static AudioSource aso;
	static AudioMixer am;
	// Use this for initialization
	void Start () {
		aso = GetComponent<AudioSource> ();
		sounds = FindObjectsOfType<AudioSource> ();
		am = FindObjectOfType<AudioMixer> ();
	}
	public static void PlaySource(bool allSounds = false){
		aso.Play ();
	}
	public static void PauseSound(bool pause){
		foreach (AudioSource a in sounds) {
			if (pause) {
				aso.Pause ();
			} else {
				aso.UnPause ();
			}
		}
	}
	public void Mute(){
		sounds [0].outputAudioMixerGroup.audioMixer.SetFloat ("Master", 0);
	}
}
