using UnityEngine;
using System.Collections;

public class BronzeKey : Key {	
	// Update is called once per frame
	new void OnCollisionEnter (Collision c) {
		if (c.gameObject.tag == "Player") {
			LockedRabbit.key = true;
			DestroyKey ();
		}	
	}
}
