using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour {

	public GameObject C1;
	public GameObject C2;
	public GameObject C3;

	public GameObject C1Clone;
	public GameObject C2Clone;
	public GameObject C3Clone;

	public bool C1Left;
	public bool C2Left;
	public bool C3Left;

	void Start () 
	{
		C1 = GameObject.Find ("C1");
		C2 = GameObject.Find ("C2");
		C3 = GameObject.Find ("C3");

		C1Clone = GameObject.Find ("C1Clone");
		C2Clone = GameObject.Find ("C2Clone");
		C3Clone = GameObject.Find ("C3Clone");

		C1Left = true;
		C2Left = false;
		C3Left = true;

		C1Clone.SetActive (false);
		C2Clone.SetActive (false);
		C3Clone.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{ mirrorLeft(); }

		if (Input.GetKeyDown (KeyCode.RightShift)) 
		{ mirrorRight(); }
	}

	void mirrorLeft () 
	{
		if (C1Left == true) 
		{ C1Clone.SetActive (true); }

		if (C2Left == false) 
		{ C2.SetActive (false); }

		if (C2Left == true) 
		{ 
			C2.SetActive (true);
		}


		if (C3Left == true) 
		{ C3Clone.SetActive (true); }
	}

	void mirrorRight () 
	{
		if (C1Left == true) 
		{ C1.SetActive (false); }
		
		if (C2Left == false) 
		{ C2Clone.SetActive (true); }

		if (C2Left == true) 
		{ 
			C2Clone.SetActive (false);
		}

		if (C3Left == true) 
		{ C3.SetActive (false); }
	}

	void moveSideC1 () 
	{ 
		if (C1Left == false) 
		{ C1Left = true; }

		if (C1Left == true) 
		{ C1Left = false; }
	}

	void moveSideC2 () 
	{ 
		Debug.Log ("derp2");

		if (C2Left == false) 
		{ C2Left = true; }
	
	}

	void moveSideC3 () 
	{ 
		if (C3Left == false) 
		{ C3Left = true; }
		
		if (C3Left == true) 
		{ C3Left = false; }
	}

}
