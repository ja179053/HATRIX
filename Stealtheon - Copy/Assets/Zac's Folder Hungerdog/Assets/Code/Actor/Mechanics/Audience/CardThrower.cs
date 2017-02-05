using UnityEngine;
using System.Collections;

[AuthorAttribute ("Zac", TeamRole.Designer)]
public class CardThrower : MonoBehaviour {

	public Rigidbody card;
//	public Transform player; CHANGED TO USE transform INSTEAD

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E))
		{
			Rigidbody cardInstance;
		//	cardInstance = Instantiate (card, player.position, card.rotation) as Rigidbody;
			//	cardInstance.AddForce (player.forward* 999);
			cardInstance = Instantiate (card, transform.position, card.rotation) as Rigidbody;
			cardInstance.AddForce(transform.forward * 999);
		}
	}
}
