using UnityEngine;
using System.Collections;

namespace Actor
{
	public class Metamorphosis : MonoBehaviour
	{
		public float smokeDuration = 2;
		static bool preteleport = false;
		static GameObject metamorphosis;
		static ParticleSystem smoke;
		static bool smokeNow = false;
		void Start(){
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
				metamorphosis.transform.position = ABehaviour.currentPos;
			} else {
				ABehaviour.SetTeleport (metamorphosis.transform.position);
			}
		}

		void Update(){
			if (smokeNow) {
				smokeNow = false;
				StartCoroutine (ActivateSmoke ());
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
