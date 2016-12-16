using UnityEngine;
using System.Collections;
[AuthorAttribute ("JJ", TeamRole.Programmer)]
//EnemyLook is the non-abstract enemy class used for patrolling and player detection.
public class EnemyLook : EnemyMove
{
	//Controls the angle and distance of spotting.
	public float sight = 1, scanRadius;
	//Ray used to detect the player.
	Ray ray;
	//TempPos used to draw gizmos.
	Vector3 tempPos;
	Quaternion direction;

	//Initialises CharacterSettings, determines if AI can patrol and starts search coroutine.
	void Start ()
	{
		CharacterSettings ();
		direction = new Quaternion ();
		if (patrolPoints.Length < 2) {
			wander = true;
		}
		if (wander) {
		} else {
			LookForward ();
			NewTarget (patrolPoints [currPatrolPoint]);
		}
		if (scanRadius > 0) {
			StartCoroutine (ScanRadius ());
		}
	}
	//Draws a ray forward
	//Casts a ray to catch the player or the next patrol point
	void Update ()
	{
		Debug.DrawRay (transform.position, transform.forward * sight);
		RaycastHit rayInfo;
		if (Physics.Raycast (ray, out rayInfo, sight)) {
			if (!wander) {
				Patrol (rayInfo);
			}
			if (rayInfo.collider.tag == "Player") {
				Debug.Log ("GAME OVER");
			} 
		}
		if (shouldMove) {
			transform.position = Vector3.MoveTowards (transform.position, currTarget, Time.deltaTime * moveSpeed);
		}
		direction = Quaternion.LookRotation (currTarget - transform.position);
		//transform.rotation = direction;
		transform.rotation = Quaternion.Slerp (transform.rotation, direction, Time.deltaTime * moveSpeed);
	}
	//Calculates a new direction to look in based on scanRadius. Updates every 0.1s.
	IEnumerator ScanRadius ()
	{
		float disposition = Random.Range (-scanRadius, scanRadius);
		tempPos = transform.position + (transform.forward * sight) + (transform.right * disposition);
	//	Instantiate (GameObject.CreatePrimitive (PrimitiveType.Cube), tempPos, Quaternion.identity);
		Vector3 direction = tempPos - transform.position;
		ray = new Ray (transform.position, direction);
		Debug.DrawRay (transform.position, direction * sight, Color.black);
		yield return new WaitForSeconds (0.1f);
		StartCoroutine (ScanRadius());
	}
	//Draws a red wiresphere at tempPos.
	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (tempPos, 0.2f);
	}
}
