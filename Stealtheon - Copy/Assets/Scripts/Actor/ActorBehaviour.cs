﻿using UnityEngine;
using System.Collections;

public class ActorBehaviour : MonoBehaviour
{
	
	public Transform cages;
	ParticleSystem ps;
	static GameObject metamorphis;
	ActorMovement move;
	bool preteleoprt;
	//Initialises character settings
	void Start ()
	{
		ps = GetComponentInChildren<ParticleSystem> ();
		move = GetComponentInChildren<ActorMovement> ();
		metamorphis = GameObject.Find ("Metamorphis box");
		StartCoroutine (ActivateSmoke ());
	}
	IEnumerator ActivateSmoke(){
		ps.Play ();
		yield return new WaitForSeconds (2);
		ps.Stop ();
	}

	// Moves the actor and raycasts to determine if finish has been accessed.
	//256 is the number for the "Floor" layer
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.L)) {
			CageSwitch ();		
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			//	GetComponent<Animation> ().Play ();
		} else if (Input.GetKeyDown (KeyCode.A)) {
			preteleoprt = !preteleoprt;
			StartCoroutine (ActivateSmoke ());
			if (preteleoprt) {
				metamorphis.transform.position = transform.position;
			} else {
				transform.position = metamorphis.transform.position;
			}
		} else if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Break();
			Application.Quit ();
		}
	}

	static bool gotKey;

	void OnCollisionEnter (Collision c)
	{
		if (c.gameObject.tag == "Locked Door" && gotKey) {
			c.collider.enabled = false;
			Debug.Log ("unlocked");
		} else if (c.gameObject.tag == "Key") {
			Destroy (c.gameObject);
			gotKey = true;
		} else if (c.gameObject.tag == "Cage switch") {
			CageSwitch ();
		} 
	}

	void OnTriggerEnter (Collider c)
	{
		if (ActorMovement.canInput && c.gameObject.tag == "Teleporter") {
			move.Teleport (c.transform.parent.transform.position);
			/*OffMeshLink oml = c.gameObject.GetComponent<OffMeshLink> ();
			if (c.transform != oml.startTransform) {
				move.Teleport (oml.startTransform.position + Vector3.forward);
			} else {
				move.Teleport(oml.endTransform.position + Vector3.forward);
			}*/
		} else if (!ActorMovement.canInput && c.gameObject.tag == "Teletarget") {		
			ActorMovement.canInput = true;
		}
	}

	void CageSwitch ()
	{
		if (cages == null) {
			cages = GameObject.Find ("Cages").transform;
		}
		Information.conveyorDirection *= -1;
		cages.position = new Vector3 (cages.position.x, 19, cages.position.z);	
	}
}

