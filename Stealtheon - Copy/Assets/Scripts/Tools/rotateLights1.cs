using UnityEngine;
using System.Collections;

namespace Tools{
[Author ("Zac", TeamRole.Designer)]
public class rotateLights1 : MonoBehaviour {
		public bool up = true, right = true, forward = true;
	public float speed = 1f;

	void Start () 
	{
	
	}

	void Update () 
	{
			if (up) {
				transform.Rotate (Vector3.up, speed, Space.World);
			}
			if (right) {
				transform.Rotate (Vector3.right, speed, Space.World);
			}
			if (forward) {
				transform.Rotate (Vector3.forward, speed, Space.World);
			}
	}
	}
}
