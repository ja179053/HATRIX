using UnityEngine;
using System.Collections;

public class Actor2D : MonoBehaviour {
	Rigidbody2D rb;
	public float speed = 1, jumpForce = 100;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (new Vector2(Input.GetAxis ("Horizontal") * speed, 0));
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (jumpForce * transform.up);
		}
	}
}
