using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandbag : MonoBehaviour {

	public Rigidbody sandbagRigid;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void triggered () 
	{
		sandbagRigid.constraints &= ~RigidbodyConstraints.FreezePositionY;
	}

}
