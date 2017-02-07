using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sangbagtriggerscript : MonoBehaviour {

	bool inPosition;
	public GameObject thesandbag;
	public GameObject sandbagwall;

	void Start () 
	{ 
		inPosition = false;
		sandbagwall.SetActive (true);
	}

	void Update () 
	{
		if (inPosition == true && Input.GetKey (KeyCode.E)) 
		{
			sandbagwall.SetActive (false);
			thesandbag.SendMessage ("triggered");
		}
	}

	void OnTriggerEnter (Collider Other) 
	{
		if (Other.gameObject.tag == "Player")
		{ inPosition = true; }
	}

	void OnTriggerExit (Collider Other) 
	{
		if (Other.gameObject.tag == "Player")
		{ inPosition = false; }
	}

}
