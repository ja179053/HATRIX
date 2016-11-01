using UnityEngine;
[AuthorAttribute ("JJ", TeamRole.Programmer)]
//FollowScript is used to follow a target. A target to look at can be assigned too.
public class FollowScript : MonoBehaviour
{
	public Transform[] targets, lookAtTargets;
	/*public*/ GameObject[] actors;
	Transform actor;
	Transform myPos;
	public float cameraSpeed = 1, extraDistance = 0;
	public Vector3 extra;
	NavMeshAgent nma;
	public bool x = true, y = true, z = true;

	void Start ()
	{
		actors = GameObject.FindGameObjectsWithTag ("Player");
		if (GetComponent <NavMeshAgent> () != null) {
			nma = GetComponent<NavMeshAgent> ();
		}
		for (int i = 0; i < actors.Length; i++) {
			if (actors [i] != null) {
				actor = actors [i].transform;
				break;
			}
		}
		if (actor == null) {
			Debug.LogError ("ACTOR NOT ASSIGNED TO CAMERA " + gameObject.name);
		}
	}
	// Moves towards a target and looks towards a 2nd target. Extra position can be added in the inspector.
	void FixedUpdate ()
	{
		if (actor != null) {
			myPos = actor;
		} else {
			myPos = transform;
		}
		if (nma == null) {
			Vector3 newTarget;
			if (targets.Length > 0) {
				newTarget = targets [ClosestTarget (targets)].position;
			} else {
				newTarget = actor.position;
			}
			if (!x) {
				newTarget.x = transform.position.x;
			}
			if (!y) {
				newTarget.y = transform.position.y;
			}
			if (!z) {
				newTarget.z = transform.position.z;
			}
			transform.position = Vector3.Lerp (transform.position, newTarget + extra, Time.fixedDeltaTime * cameraSpeed);
		} else {
			nma.SetDestination (myPos.position + extra);
		}
		//	Debug.Log ("Closest is " + ClosestTarget (targets).name + " " + Vector3.Distance(myPos.position, ClosestTarget(targets).position));
		//	Debug.Log (targets [3].name + " " + Vector3.Distance (myPos.position, targets [3].position));
		//	transform.LookAt (ClosestTarget());
		if (lookAtTargets.Length > 0) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (lookAtTargets [ClosestTarget (lookAtTargets)].position - transform.position), Time.fixedDeltaTime * cameraSpeed);
		}
	}
	//Determines the closest of the lookAtTargets;
	int ClosestTarget (Transform[] zeroTransform)
	{
		Vector3 closest = zeroTransform [0].position;
		int j = 0;
		for (int i = 0; i < zeroTransform.Length; i++) {
			if (zeroTransform.Length > 1) {
				if (zeroTransform [i].gameObject.activeInHierarchy) {
					Vector3 target = zeroTransform [i].position;
					if (!x) {
						target.x = closest.x = 0;
					}
					if (!y) {
						target.y = closest.y = 0;
					} 
					if (!z) {
						target.z = closest.z = 0;
					}
					if ((Vector3.Distance (myPos.position, closest) + extraDistance) > (Vector3.Distance (myPos.position, target))) {
						closest = zeroTransform [i].position;
						j = i;
					}
				}
			}
		}
		if (zeroTransform == targets && gameObject.tag == "MainCamera") {
			ActorMovement.MovementType = j;
		}
	//	Debug.Log (name + " " + zeroTransform[j].name);
		return j;
	}
/*	Renderer render;
	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Teleporter") {
			render.enabled = !render.enabled;
		}
	}*/
}
