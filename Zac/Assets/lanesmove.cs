using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanesmove : MonoBehaviour {

	public float speed = 6f;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		if (Input.GetKey (KeyCode.A)) 
		{ transform.Translate (Vector2.left * speed * Time.deltaTime); }

		if (Input.GetKey (KeyCode.D)) 
		{ transform.Translate (-Vector2.left * speed * Time.deltaTime); }
	}
		
}
