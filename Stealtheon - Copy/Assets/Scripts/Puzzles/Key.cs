using UnityEngine;
using System.Collections;
using Actor;

public class Key : MonoBehaviour {
	// Update is called once per frame
	void OnCollisionEnter (Collision c) {
		if (c.gameObject.tag == "Player") {
			ActorController.gotKey = true;
			DestroyKey ();
		}	
	}
	protected void DestroyKey () {
		Destroy (this.gameObject);	
	}
}
