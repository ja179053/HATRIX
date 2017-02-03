using UnityEngine;
using System.Collections;

namespace Actor
{
	[AuthorAttribute ("JJ", TeamRole.Programmer)]
	public class ActorController : ActorMovement
	{
		Transform cages;
		public GameObject mySkin, jumpSkin;
		static EndJump ejump;

		void Start(){
			pcMode = !Application.isMobilePlatform;
			if (!pcMode) {
				Application.runInBackground = false;
				Screen.autorotateToLandscapeLeft = true;
			}
			Debug.Log (pcMode);
			nma = GetComponent<NavMeshAgent> ();
			//chCo = GetComponentInParent<CharacterController> ();
			anim = GetComponentInChildren<Animator> ();
			ejump = GetComponentInChildren<EndJump> ();
			ejump.gameObject.SetActive (false);
			try{
			cages = GameObject.Find ("Cages").transform;
			} catch{
			}
		}

		void OnTriggerEnter (Collider c)
		{
			if (ActorMovement.canInput && c.gameObject.tag == "Teleporter") {
				//	SetTeleport (c.transform.parent.transform.position);-
				StartCoroutine(ejump.Jump(c.gameObject.GetComponent<OffMeshLink> (), c.transform == c.gameObject.GetComponent<OffMeshLink> ().transform));
			} else if (!ActorMovement.canInput && c.gameObject.tag == "Teletarget") {	
						StartCoroutine(ejump.Jump (null, false, false));	
			} else if (c.gameObject.tag == "Cage switch") {
				c.GetComponent<Animation> ().Play ();
				CageSwitch ();
			} else if (c.gameObject.tag == "Locked Door" && gotKey) {
				gotKey = false;
				c.GetComponent<Animation> ().Play ();
			//	c.enabled = false;
				//WARPS UNTIL ANIMATION IS IN
				ActorMovement.Teleport (c.transform.parent.transform.position, true);
			}
		}

		public void SwitchSkins(bool jumping){
			mySkin.GetComponentInChildren<SkinnedMeshRenderer> ().enabled = !jumping;
			jumpSkin.SetActive(jumping);
			anim.SetBool ("Jumping", jumping);
		}

		public static bool gotKey = false;

		void OnCollisionEnter (Collision c)
		{
			if (c.gameObject.tag == "Key") {
				Destroy (c.gameObject);
				gotKey = true;
			} 
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
