using UnityEngine;
using System.Collections;
namespace Extensions{
	public static class AnimationPingPong {
		public static IEnumerator PingPongOnce(this Animation anim){
			anim.Play ();
			Debug.Log (anim.clip + " " + anim.clip.apparentSpeed);
			yield return new WaitForSeconds (anim.clip.length*2);
		//	yield return new WaitUntil  (() => anim[anim.clip.name].speed < 0);
			anim.Stop ();
		}
}
}