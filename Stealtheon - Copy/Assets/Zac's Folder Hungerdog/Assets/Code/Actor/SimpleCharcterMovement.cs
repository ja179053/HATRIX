using UnityEngine;
using System.Collections;
[AuthorAttribute ("Zac", TeamRole.Designer)]
public class SimpleCharcterMovement : MonoBehaviour {

	public float speed = 9f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 

	{
		if (Input.GetKey (KeyCode.A)) 
		{ transform.Translate (Vector3.left * Time.deltaTime * speed); }

		if (Input.GetKey (KeyCode.D)) 
		{ transform.Translate (-Vector3.left * Time.deltaTime * speed); }

		if (Input.GetKey (KeyCode.Space)) 
		{ transform.Translate (Vector3.up * Time.deltaTime * speed); }
	}

}
