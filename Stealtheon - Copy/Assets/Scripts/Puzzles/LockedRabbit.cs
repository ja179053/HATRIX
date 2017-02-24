using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AuthorAttribute ("Zac", TeamRole.Designer)]
public class LockedRabbit : MonoBehaviour
{

	public static bool key = false;
	public GameObject goldKey, thelock = null;

	void OnCollisionStay (Collision Other)
	{
	//	Debug.Log (Other.gameObject.name);
	//	if (key && Input.GetKey (KeyCode.E)) { 
		Debug.Log(Other.collider.name + "the lock is " + thelock.activeSelf);
		if (thelock) {
			if (key && Other.gameObject.tag == "Player") {
				this.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
				key = false;
				Destroy (thelock);
				Instantiate (goldKey, transform.position + transform.up + transform.forward, Quaternion.identity);
			}
		}
	//	}
	}

}
