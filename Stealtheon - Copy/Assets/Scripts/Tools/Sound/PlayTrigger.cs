using UnityEngine;
using System.Collections;

public class PlayTrigger : MonoBehaviour {
	public float delaytime;
	public bool once = true, canTrigger = true;
	public AudioSource aso;
	AudioClip defaultClip;
	void OnTriggerEnter(Collider c){
		if (once && canTrigger) {
			GetComponent<Collider> ().enabled = false;
		}
		StartCoroutine (Play (defaultClip));
	}
	public IEnumerator Play(AudioClip ac = default (AudioClip)){
		aso.clip = ac;
		yield return new WaitForSeconds (delaytime);
		if (!aso.isPlaying) {
			aso.Play ();
		}
	}
	void Start(){
		if (aso == null) {
			aso = GetComponent<AudioSource> ();
			defaultClip = aso.clip;
		}
	}
}
