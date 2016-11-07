using UnityEngine;

public abstract class EnemyMove : Character
{
	//Patrol points can be dragged on in the inspector view.
	public Transform[] patrolPoints;
	//The current target is monitored here.
	Transform currTarget;
	//The point in patrolPoints is measured with this int.
	protected int currPatrolPoint = 0;
	//Whether the AI wanders or patrols.
	protected bool wander;

	//Updates the current target in script and NavMeshAgent
	protected void NewTarget (Transform target)
	{
		currTarget = target;
		nma.SetDestination (target.position);
	}
	//When a patrol target is met, updates a new patrol target.
	protected void Patrol (RaycastHit rayInfo)
	{
		if (rayInfo.collider.tag == "Patrol Point") {
			if (int.Parse ("" + rayInfo.collider.name [14]) - 1 == currPatrolPoint) {
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
