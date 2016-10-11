using UnityEngine;
using System.Collections;

public class ReleaseButton : MonoBehaviour {
	public Rigidbody r;
	// Use this for initialization
	void Start () {
		r.isKinematic = true;
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision c) {
		if (c.gameObject.tag == "Player") {
			GetComponent<Collider> ().enabled = false;
			r.isKinematic = false;
		}
	}
}
