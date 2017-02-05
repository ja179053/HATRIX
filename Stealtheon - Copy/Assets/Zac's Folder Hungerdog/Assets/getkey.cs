using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getkey : MonoBehaviour {

	public GameObject key;
	public GameObject lockedrabbit;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter (Collider Other)
	{
		if (Other.gameObject.tag == "Player")
		{ 
			lockedrabbit.SendMessage ("keygotten");
			key.SetActive (false);
		}
	}
}
