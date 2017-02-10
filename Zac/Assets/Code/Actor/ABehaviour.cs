using UnityEngine;
using System.Collections;

namespace Actor
{
	[AuthorAttribute ("JJ", TeamRole.Programmer)]
	public class ABehaviour : MonoBehaviour
	{

		Transform cages;
		static ParticleSystem ps;
		static ActorMovement move;
		public static Vector3 currentPos;
		public string metamorphosisKey = "x";
		//Initialises character settings
		void Start ()
		{
			ps = GetComponentInChildren<ParticleSystem> ();
			move = GetComponentInChildren<ActorMovement> ();
			cages = GameObject.Find ("Cages").transform;
		}

		// Moves the actor and raycasts to determine if finish has been accessed.
		//256 is the number for the "Floor" layer
		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.L)) {
				//	CageSwitch ();		
			} else if (Input.GetKeyDown (KeyCode.Space)) {
				//	GetComponent<Animation> ().Play ();
			} else if (Input.GetKeyDown (metamorphosisKey)) {
				currentPos = transform.position;
				Actor.Metamorphosis.MetamorphosisInput ();
			} else if (Input.GetKeyDown (KeyCode.Escape)) {
				GameManager.Paused = !GameManager.Paused;
			}
		}

		public static bool gotKey = false;

		void OnCollisionEnter (Collision c)
		{
			if (c.gameObject.tag == "Key") {
				Destroy (c.gameObject);
				gotKey = true;
			} 
		}

		void OnTriggerEnter (Collider c)
		{
			if (ActorMovement.canInput && c.gameObject.tag == "Teleporter") {
				SetTeleport (c.transform.parent.transform.position);
				/*OffMeshLink oml = c.gameObject.GetComponent<OffMeshLink> ();
			if (c.transform != oml.startTransform) {
				move.Teleport (oml.startTransform.position + Vector3.forward);
			} else {
				move.Teleport(oml.endTransform.position + Vector3.forward);
			}*/
			} else if (!ActorMovement.canInput && c.gameObject.tag == "Teletarget") {		
				ActorMovement.canInput = true;
			} else if (c.gameObject.tag == "Cage switch") {
				c.GetComponent<Animation> ().Play ();
				CageSwitch ();
			} else if (c.gameObject.tag == "Locked Door" && gotKey) {
				gotKey = false;
				c.GetComponent<Animation> ().Play ();
				c.enabled = false;
				Debug.Log ("found the door");
				SetTeleport (c.transform.parent.transform.position);
			}
		}
		public static void SetTeleport(Vector3 v){
			move.Teleport (v);
		}

		void CageSwitch ()
		{
			if (cages == null) {
				cages = GameObject.Find ("Cages").transform;
			}
			Information.conveyorDirection *= -1;
			cages.position += (Vector3.up * 17);
		}
	}

}