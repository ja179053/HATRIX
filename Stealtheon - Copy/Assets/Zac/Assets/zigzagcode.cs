using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zigzagcode : MonoBehaviour {

	public GameObject lowleft;
	public GameObject lowmiddle;
	public GameObject lowright;
	public GameObject highleft;
	public GameObject highmiddle;
	public GameObject highright;

	public bool inPosition;
	public bool zigzag1;
	public bool zigzag2;

	void Start () 
	{
		inPosition = false;
		zigzag1 = true;
		zigzag2 = false;
		lowleft.SetActive (false);
		lowmiddle.SetActive (true);
		lowright.SetActive (false);
		highleft.SetActive (false);
		highmiddle.SetActive (true);
		highright.SetActive (false);
	}

	void Update () 
	{
		if (inPosition == true && Input.GetKeyDown (KeyCode.E)) 
		{ ZigZag (); }
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

	void ZigZag () 
	{
		if (zigzag1 == true)
		{
			lowleft.SetActive (true);
			lowmiddle.SetActive (false);
			lowright.SetActive (false);
			highleft.SetActive (false);
			highmiddle.SetActive (false);
			highright.SetActive (true);
			zigzag1 = false;
			zigzag2 = true;
		}
		else
		{
			lowleft.SetActive (false);
			lowmiddle.SetActive (false);
			lowright.SetActive (true);
			highleft.SetActive (true);
			highmiddle.SetActive (false);
			highright.SetActive (false);
			zigzag2 = false;
			zigzag1 = true;
		}
			
	}
}
