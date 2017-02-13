using UnityEngine;
using System.Collections;

public class ResetIdle : StateMachineBehaviour {
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		IdleB.Reset ();
	}
}
