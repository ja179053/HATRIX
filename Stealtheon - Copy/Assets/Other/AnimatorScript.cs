using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {

	Animator JackelopeAnim;
	public GameObject JackelopeModel;

	// Use this for initialization
	void Start () {
		JackelopeAnim = GetComponent <Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		bool isRunningA = Input.GetKey ("a");
		JackelopeAnim.SetBool ("isRunninh2", isRunningA);

		bool isRunningD = Input.GetKey ("d");
		JackelopeAnim.SetBool ("isRunninh", isRunningD);

		if (Input.GetKeyDown (KeyCode.A)) 
		{ JackelopeModel.transform.Rotate (0, 90, 0); }

		if (Input.GetKeyUp (KeyCode.A)) 
		{ JackelopeModel.transform.Rotate (0, 270, 0); }

		if (Input.GetKeyDown (KeyCode.D)) 
		{ JackelopeModel.transform.Rotate (0, 270, 0); }

		if (Input.GetKeyUp (KeyCode.D)) 
		{ JackelopeModel.transform.Rotate (0, 90, 0); }

	}
}