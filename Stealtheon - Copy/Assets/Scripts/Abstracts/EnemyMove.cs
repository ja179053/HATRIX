using UnityEngine;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public abstract class EnemyMove : Character
{
	//Patrol points can be dragged on in the inspector view.
	//When this object collides with a patrol point, the patrol point is updated.
	public Transform[] patrolPoints;
	//The current target is monitored here.
	public Vector3 currTarget;
	//The point in patrolPoints is measured with this int.
	protected int currPatrolPoint = 0;
	//Whether the AI wanders or patrols.
	protected bool wander, shouldMove;

	//Updates the current target in script and NavMeshAgent
	protected void NewTarget (Transform target)
	{
		currTarget = target.position;
		if (nma != null) {
			nma.SetDestination (currTarget);
		} else {
			BoxCollider bc = target.GetComponent<BoxCollider> ();
			currTarget += bc.center + (bc.size / 2);
			shouldMove = true;
		//	LookForward ();	
		}
	}
	protected void LookForward(){
		transform.LookAt (patrolPoints [currPatrolPoint]);
	}
	//When a patrol target is met, updates a new patrol target.
	protected void Patrol (RaycastHit rayInfo)
	{
		if (rayInfo.collider.tag == "Patrol Point") {
			Debug.Log (rayInfo.collider.name[13]);
			string s = "" + rayInfo.collider.name [13];
			int i = 0;
			if (rayInfo.collider.name.Length > 14) {
				if (int.TryParse (s + rayInfo.collider.name [14], out i)) {
					s += rayInfo.collider.name [14];
				}
			}
			if (int.Parse (s) - 1 == currPatrolPoint) {
				if (currPatrolPoint != patrolPoints.Length - 1) {
					currPatrolPoint++;
				} else {
					currPatrolPoint = 0;
				}
				NewTarget (patrolPoints [currPatrolPoint]);
			}
		}
	}
}
