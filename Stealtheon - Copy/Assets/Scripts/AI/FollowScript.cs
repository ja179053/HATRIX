using UnityEngine;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
//FollowScript is used to follow a target. A target to look at can be assigned too.
public class FollowScript : MonoBehaviour
{
	public Transform[] targets, lookAtTargets;
	/*public*/
	GameObject[] actors;
	Transform myPos, currFollowTarget;
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
				myPos = actors [i].transform;
				break;
			}
		}
		if (myPos == null) {
			Debug.LogError ("ACTOR NOT ASSIGNED TO CAMERA " + gameObject.name);
			myPos = transform;
		}
	}
	// Moves towards a target and looks towards a 2nd target. Extra position can be added in the inspector.
	//NEEDS NEWTARGET TO COUNTERACT XYZ WHEN NEEDED.
	void FixedUpdate ()
	{
		if (nma == null) {
			Vector3 newTarget = new Vector3 ();
			if(currFollowTarget){
				newTarget = currFollowTarget.position;
			}
			if (targets.Length > 0) {
				int i = ClosestTarget (targets);
				if (targets [i].position != newTarget) {
					currFollowTarget = targets [i];
					newTarget = currFollowTarget.position;
				}
			} else {
				newTarget = myPos.position;
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
		//	Debug.Log ("Closest is " + targets[ClosestTarget (targets)].name + " " + Vector3.Distance(myPos.position, targets[ClosestTarget(targets)].position) + " from " + name);
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
			Actor.ActorMovement.MovementType = j;
		}
		//	Debug.Log (name + " " + zeroTransform[j].name);
		return j;
	}
}
