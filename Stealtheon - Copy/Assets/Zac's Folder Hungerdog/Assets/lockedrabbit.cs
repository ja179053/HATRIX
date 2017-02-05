using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedrabbit : MonoBehaviour {

	public bool key;
	public bool inPosition;

	public GameObject thelock;

	// Use this for initialization
	void Start () 
	{
		key = false;
		inPosition = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (key == true && inPosition == true && Input.GetKey (KeyCode.E)) 
		{ thelock.SetActive (false); }
	}

	void keygotten () 
	{ key = true; }

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
