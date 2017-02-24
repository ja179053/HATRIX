using UnityEngine;
using System.Collections;
using Extensions;

public class SandbagActivator : MonoBehaviour {
	public BoxCollider bc;
	// Update is called once per frame
	void OnTriggerEnter () {
		StartCoroutine(bc.GetComponentInParent<Animation>().PingPongOnce());
		bc.isTrigger = true;
	}
}
