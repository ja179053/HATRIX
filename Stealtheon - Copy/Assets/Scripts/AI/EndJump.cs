using UnityEngine;
using System.Collections;

namespace Actor
{
	public class EndJump : MonoBehaviour
	{

		public IEnumerator Jump (OffMeshLink oml, bool b, bool jumping = true)
		{
			if (jumping) {
				GetComponentInParent<ActorController> ().SwitchSkins (true);
				if (b) {
					//Sometimes this does not move the character.
					ActorMovement.Teleport (oml.endTransform.position + Vector3.forward);
				} else {
					ActorMovement.Teleport (oml.startTransform.position + Vector3.forward);
				}
			} else {
				ActorMovement.canInput = true;
			}
			while (ActorMovement.canInput != true) {
				yield return null;
			}
			yield return new WaitForSeconds (0.5f);
			GetComponentInParent<ActorController> ().SwitchSkins (jumping);
		}

		public void No ()
		{
			StopCoroutine (Jump (null, false, false));
			StartCoroutine (Jump (null, false, false));
		}
	}
}
