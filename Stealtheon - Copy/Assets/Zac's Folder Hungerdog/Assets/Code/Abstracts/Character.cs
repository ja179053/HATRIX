using UnityEngine;
[AuthorAttribute ("JJ", TeamRole.Programmer)]
//Character is a parent abstract class to set up all characters.
public abstract class Character : MonoBehaviour
{
	//Accessor to the NavMeshAgent
	protected UnityEngine.AI.NavMeshAgent nma;
	//Character movespeed;
	public float moveSpeed;

	//Sets the NavMeshAgent
	protected void CharacterSettings ()
	{
		nma = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		SetNMASpeed (moveSpeed);
	}
	//Sets the nma speed;
	protected void SetNMASpeed(float speed){
		nma.speed = speed;
	}
}
