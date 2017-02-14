using UnityEngine;
using System.Collections;

public class IdleB : StateMachineBehaviour {
	static float idleTime = 0;
	public float maxIdleTime = 5;

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		idleTime += Time.fixedDeltaTime;
		CheckToZoom ();
	}
	void CheckToZoom(){
		if (idleTime > maxIdleTime) {
			CameraZoom.Zoom (true);
		}
	}
	public static void Reset(){
		idleTime = 0;
		CameraZoom.Zoom (false);
	}
}
