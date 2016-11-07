using UnityEngine;
using System.Collections;

public class cardExample : MonoBehaviour {

	public Rigidbody card;
	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E))
		{
			Rigidbody cardInstance;
			cardInstance = Instantiate (card, player.position, card.rotation) as Rigidbody;
			cardInstance.AddForce (player.forward* 999);
		}
	}
}
