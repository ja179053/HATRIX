using UnityEngine;
using System.Collections;

public class P1Movement : MonoBehaviour {
	
	public GameObject player;
	public GameObject theLanes;
	public GameObject room1posros;
	public GameObject room2posros;
	public GameObject room3posros;
	public GameObject room4posros;

	public float speed = 6f;

	public bool Room1;
	public bool Room2;
	public bool Room3;
	public bool Room4;

	public bool inLane1;
	public bool inLane2;
	public bool inLane3;

	public GameObject lane1;
	public GameObject lane2;
	public GameObject lane3;

	void Start () 
	{
		inLane2 = true;
		Room1 = true;
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.A)) 
		{ 
			transform.Translate (Vector2.left * speed * Time.deltaTime);
			theLanes.transform.Translate (Vector2.left * speed * Time.deltaTime);

		}

		if (Input.GetKey (KeyCode.D)) 
		{ 
			transform.Translate (-Vector2.left * speed * Time.deltaTime); 
			theLanes.transform.Translate (-Vector2.left * speed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.W)) 
		{ MoveBackwards(); }

		if (Input.GetKeyDown (KeyCode.S)) 
		{ MoveForwards(); }

	}

	void MoveBackwards () 
	{
		if (inLane2 == true) 
		{
			player.transform.position = lane3.transform.position;
			inLane3 = true;
			inLane2 = false;
		}

		if (inLane1 == true) 
		{
			player.transform.position = lane2.transform.position;
			inLane2 = true;
			inLane1 = false;
		}
	}

	void MoveForwards () 
	{
		if (inLane2 == true) 
		{
			player.transform.position = lane1.transform.position;
			inLane1 = true;
			inLane2 = false;
		}
		
		if (inLane3 == true) 
		{
			player.transform.position = lane2.transform.position;
			inLane2 = true;
			inLane3 = false;
		}
	}

	void InRoom1 () 
	{
		transform.Rotate(0, 90, 0);
		theLanes.transform.Rotate(0, 90, 0);

		Room1 = true;
		Room2 = false;
		Room3 = false;
		Room4 = false;
	}

	void InRoom2 () 
	{
		transform.Rotate(0, 90, 0);
		theLanes.transform.Rotate (0, 90, 0);

		Room1 = false;
		Room2 = true;
		Room3 = false;
		Room4 = false;
	}

	void InRoom3 () 
	{
		transform.Rotate(0, 90, 0);
		theLanes.transform.Rotate(0, 90, 0);

		Room1 = false;
		Room2 = false;
		Room3 = true;
		Room4 = false;
	}

	void InRoom4 () 
	{
		transform.Rotate(0, 90, 0);
		theLanes.transform.Rotate (0, 90, 0);

		Room1 = false;
		Room2 = false;
		Room3 = false;
		Room4 = true;
	}
}
