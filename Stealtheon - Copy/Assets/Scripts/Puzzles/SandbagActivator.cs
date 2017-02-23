using UnityEngine;
using System.Collections;

public class SandbagActivator : MonoBehaviour {
	public BoxCollider bc;
	// Update is called once per frame
	void OnTriggerEnter () {
		bc.isTrigger = true;
		bc.GetComponentInParent<Animation> ().Play ();
	}
}
