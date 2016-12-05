using UnityEngine;
using System.Collections;

public class Middle : MonoBehaviour {

	public GameObject MirrorController;

	void Start () 
	{
	}

	void Update () 
	{
	
	}

	void OnTriggerEnter (Collider Other)
	{
		if (Other.gameObject.name == "C1") 
		{ MirrorController.SendMessage ("moveSideC1"); }

		if (Other.gameObject.name == "C2") 
		{ MirrorController.SendMessage ("moveSideC2"); }

		if (Other.gameObject.name == "C3") 
		{ MirrorController.SendMessage ("moveSideC3"); }
	}


}
