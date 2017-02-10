using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AuthorAttribute ("Zac", TeamRole.Designer)]
public class LockedRabbit : MonoBehaviour
{

	public static bool key = false;
	public GameObject thelock, goldKey;

	void OnCollisionStay (Collision Other)
	{
	//	Debug.Log (Other.gameObject.name);
	//	if (key && Input.GetKey (KeyCode.E)) { 
		if (thelock) {
			if (Other.gameObject.tag == "Player") {
				key = false;
				Destroy (thelock);
				Instantiate (goldKey, transform.position + transform.up + transform.forward, Quaternion.identity);
			}
		}
	//	}
	}
	void OnTriggerStay (Collider Other)
	{
	//	Debug.Log (Other.gameObject.name);
		//	if (key && Input.GetKey (KeyCode.E)) { 
		if (Other.gameObject.tag == "Player") {
			thelock.SetActive (false);
			Instantiate (goldKey, transform.position + transform.forward + transform.up, Quaternion.identity);
		}
		//	}
	}

}
