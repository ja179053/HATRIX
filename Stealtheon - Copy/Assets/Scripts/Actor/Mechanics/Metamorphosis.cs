using UnityEngine;
using System.Collections;

namespace Actor
{
	public class Metamorphosis : Singleton<Metamorphosis>
	{
		protected Metamorphosis ()
		{
		}

		static bool preteleport = false, smokeNow = false;
		static GameObject metamorphosis;
		static ParticleSystem smoke;

		public float smokeDuration = 2;
		public string metamorphosisKey = "x";

		void Start ()
		{
			ps = GetComponentInChildren<ParticleSystem> ();
			metamorphosis = GameObject.Find ("Metamorphosis box");
			smoke = GameObject.Find ("Smoke").GetComponent<ParticleSystem> ();
			if (smoke != null) {//Will not work with errors
				StartCoroutine (ActivateSmoke ());
			}
		}

		public static void MetamorphosisInput ()
		{
			preteleport = !preteleport;
			smokeNow = true;
			if (preteleport) {
				metamorphosis.transform.position = ActorMovement.currentPos;
			} else {
				ActorMovement.Teleport (metamorphosis.transform.position, true);
			}
		}

		static ParticleSystem ps;

		void Update ()
		{
			if (smokeNow) {
				smokeNow = false;
				StartCoroutine (ActivateSmoke ());
			}
			if (Input.GetKeyDown (metamorphosisKey)) {
				ActorMovement.currentPos = transform.position; 
				MetamorphosisInput ();
			}
		}

		IEnumerator ActivateSmoke ()
		{
			if (smoke != null) {
				smoke.Play ();
				yield return new WaitForSeconds (smokeDuration);
				smoke.Stop ();
			}
		}
	}
}
