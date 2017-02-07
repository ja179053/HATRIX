using UnityEngine;
using System.Collections;

public class P2movement : MonoBehaviour {

	public Rigidbody playerRigid;
	public GameObject player;
	public GameObject theLanes;

	public float speed = 6f;

	public bool Room1;
	public bool Room2;
	public bool Room3;
	public bool Room4;

	public bool inLane1;
	public bool inLane2;
	public bool inLane3;
	public bool LanesFront;
	public bool LanesBack;

	public GameObject lane1;
	public GameObject lane2;
	public GameObject lane3;
	public GameObject lane12;
	public GameObject lane22;
	public GameObject lane32;

	public bool Falling;

	void Start () 
	{
		inLane2 = true;
		Room1 = true;
		Falling = false;
	}

	void Update () 
	{
		theLanes.transform.position = player.transform.position;

		if (Input.GetKeyDown (KeyCode.Backspace)) 
		{ Application.LoadLevel (Application.loadedLevel); }

		if (Input.GetKey (KeyCode.Escape)) 
		{ Application.Quit(); }

		/*
		if (Input.GetKey (KeyCode.A)) 
		{ transform.Translate (Vector2.left * speed * Time.deltaTime); }

		if (Input.GetKey (KeyCode.D)) 
		{ transform.Translate (-Vector2.left * speed * Time.deltaTime); }
		*/

		if (Input.GetKey (KeyCode.A)) 
		{ transform.Translate (-Vector2.left * speed * Time.deltaTime);}

		if (Input.GetKey (KeyCode.D)) 
		{ transform.Translate (Vector2.left * speed * Time.deltaTime); }
			

		if (Input.GetKeyDown (KeyCode.W)) 
		{ MoveBackwards(); }

		if (Input.GetKeyDown (KeyCode.S)) 
		{ MoveForwards(); }

		if (Input.GetKey (KeyCode.Space) && Falling == false) 
		{ playerRigid.AddForce (new Vector3 (0, 900, 0), ForceMode.Impulse); }
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
			player.transform.position = lane3.transform.position;
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
			player.transform.position = lane1.transform.position; 
			inLane2 = true;
			inLane3 = false;
		}
	}

	void InRoom1 () 
	{
		if (Room4 == true) 
		{
			transform.Rotate (0, 90, 0);
			theLanes.transform.Rotate (0, 90, 0);
		}

		if (Room2 == true) 
		{
			transform.Rotate (0, 270, 0);
			theLanes.transform.Rotate (0, 270, 0);
		}

		Room1 = true;
		Room2 = false;
		Room3 = false;
		Room4 = false;
	}

	void InRoom2 () 
	{
		if (Room1 == true) 
		{
			transform.Rotate (0, 90, 0);
			theLanes.transform.Rotate (0, 90, 0);
		}

		if (Room3 == true) 
		{
			transform.Rotate (0, 270, 0);
			theLanes.transform.Rotate (0, 270, 0);
		}

		Room1 = false;
		Room2 = true;
		Room3 = false;
		Room4 = false;

	}

	void InRoom3 () 
	{
		if (Room4 == true) 
		{
			transform.Rotate (0, 270, 0);
			theLanes.transform.Rotate (0, 270, 0);
		}

		if (Room2 == true) 
		{
			transform.Rotate (0, 90, 0);
			theLanes.transform.Rotate (0, 90, 0);
		}

		Room1 = false;
		Room2 = false;
		Room3 = true;
		Room4 = false;
	}

	void InRoom4 () 
	{
		if (Room1 == true) 
		{
			transform.Rotate (0, 270, 0);
			theLanes.transform.Rotate (0, 270, 0);
		}

		if (Room3 == true) 
		{
			transform.Rotate (0, 90, 0);
			theLanes.transform.Rotate (0, 90, 0);
		}

		Room1 = false;
		Room2 = false;
		Room3 = false;
		Room4 = true;
	}

	void Box1 () 
	{
		if (Room1 == true) 
		{ InRoom2 (); } 
		else
		{ InRoom1(); }
	}

	void Box2 () 
	{
		if (Room2 == true) 
		{ InRoom3 (); } 
		else
		{ InRoom2(); }
	}

	void Box3 () 
	{
		if (Room3 == true) 
		{ InRoom4 (); } 
		else
		{ InRoom3(); }
	}

	void Box4 () 
	{
		if (Room4 == true) 
		{ InRoom1 (); } 
		else
		{ InRoom4(); }
	}

	void OnCollisionEnter (Collision Other)
	{
		if (Other.gameObject.tag == "floor")
		{ Falling = false; }
	}

	void OnCollisionExit (Collision Other)
	{
		if (Other.gameObject.tag == "floor") 
		{ Falling = true; }
	}

}
