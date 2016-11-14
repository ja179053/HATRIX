using UnityEngine;
using System.Collections;

namespace Actor
{
	public class Metamorphosis : MonoBehaviour
	{
		static bool preteleport = false;
		static GameObject metamorphosis;
		void Start(){
			metamorphosis = GameObject.Find ("Metamorphosis box");
		}
		public static void MetamorphosisInput ()
		{
			if (metamorphosis == null) {
				Debug.Log ("not there");
			} else {
				Debug.Log ("there");
			}
			preteleport = !preteleport;
			if (preteleport) {
				metamorphosis.transform.position = ABehaviour.currentPos;
			} else {
				ABehaviour.SetTeleport (metamorphosis.transform.position);
			}
		}
	}
}
