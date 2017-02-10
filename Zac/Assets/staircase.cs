using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staircase : MonoBehaviour {

	public bool inposition;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () 
	{
		if (inposition == true && Input.GetKey(KeyCode.E))
		{ Application.LoadLevel (Application.loadedLevel + 1); }
	}

	void OnTriggerEnter (Collider Other)
	{ 
		if (Other.gameObject.tag == "Player") 
		{ inposition = true; }
	}

	void OnTriggerExit (Collider Other)
	{ 
		if (Other.gameObject.tag == "Player") 
		{ inposition = false; }
	}
}
