using UnityEngine;
using System.Collections;

namespace Tools{
[Author ("Zac", TeamRole.Designer)]
public class rotateLights1 : MonoBehaviour {

	public float speed = 1f;

	void Start () 
	{
	
	}

	void Update () 
	{
		transform.Rotate (Vector3.up, speed, Space.World);
		transform.Rotate (Vector3.right, speed, Space.World);
	}
	}
}
