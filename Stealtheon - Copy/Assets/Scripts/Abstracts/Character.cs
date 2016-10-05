using UnityEngine;
//Character is a parent abstract class to set up all characters.
public abstract class Character : MonoBehaviour
{
	//Accessor to the NavMeshAgent
	protected NavMeshAgent nma;
	//Character movespeed;
	public float moveSpeed;

	//Sets the NavMeshAgent
	protected void CharacterSettings ()
	{
		nma = GetComponent<NavMeshAgent> ();
	}
}
