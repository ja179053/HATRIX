using UnityEngine;
using UnityEngine.Audio;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class SoundManager : Singleton<SoundManager>
{
	protected SoundManager(){}
	//public AudioSource[]
	public AudioClip pauseS, unPauseS;
	float maxVolume = 100;
	static AudioSource[] sounds;
	static AudioSource aso;
	static AudioMixer am;
	SoundManager sm;
	// Use this for initialization
	void Start ()
	{
		aso = GetComponent<AudioSource> ();
		sounds = FindObjectsOfType<AudioSource> ();
		sm = GetComponent<SoundManager> ();
		am = FindObjectOfType<AudioMixer> ();
	}

	public static void PlaySource (bool allSounds = false)
	{
		aso.Play ();
	}

	public void PauseSound (bool pause)
	{
		foreach (AudioSource a in sounds) {
			if (a != aso) {
				if (pause) {
					a.Pause ();
				} else {
					a.UnPause ();
				}
			}
			if (pause) {
			//	aso.clip = pauseS;
			} else {
			//	aso.clip = unPauseS;
				aso.PlayOneShot (unPauseS);
			}
		//	aso.Play ();
		}
	}

	public void Mute ()
	{
		if (MasterVolume != 0) {
			maxVolume = MasterVolume;
			sounds [0].outputAudioMixerGroup.audioMixer.SetFloat ("Master", 0);
		} else {
			sounds [0].outputAudioMixerGroup.audioMixer.SetFloat ("Master", maxVolume);
		}
	}

	float MasterVolume{
		get{
			float f;
			bool result = sounds [0].outputAudioMixerGroup.audioMixer.GetFloat ("Master", out f);
			return f;
		}
	}
}
