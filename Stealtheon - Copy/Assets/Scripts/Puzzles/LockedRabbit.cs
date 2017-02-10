using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AuthorAttribute ("Zac", TeamRole.Designer)]
public class LockedRabbit : MonoBehaviour
{

	public static bool key = false;
	public GameObject thelock, goldKey;

	public static void KeyGotten ()
	{
		key = true;
	}

	void OnTriggerStay (Collider Other)
	{
		if (key && Input.GetKey (KeyCode.E)) { 
			if (Other.gameObject.tag == "Player") {
				thelock.SetActive (false);
				Instantiate (goldKey, transform.position, Quaternion.identity);
			}
		}
	}

}
