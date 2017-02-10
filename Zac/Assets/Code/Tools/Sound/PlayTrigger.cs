using UnityEngine;
using System.Collections;

public class PlayTrigger : MonoBehaviour {
	public float delaytime;
	public bool once = true;
	void OnTriggerEnter(Collider c){
		GetComponent<Collider> ().enabled = false;
		StartCoroutine (Play ());
	}
	IEnumerator Play(){
		yield return new WaitForSeconds (delaytime);
		GetComponent<AudioSource> ().Play ();
		if (once){
			Destroy (this.gameObject);
		}
	}
}
