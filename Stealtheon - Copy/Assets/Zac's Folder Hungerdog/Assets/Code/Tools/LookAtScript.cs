using UnityEngine;
using System.Collections;

namespace Tools{
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class LookAtScript : MonoBehaviour {
	public Transform target;
	public Vector3 extra;
	public Quaternion targetRotation;
	// Update is called once per frame
	void FixedUpdate () {
		if (target == null) {
			transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, Time.fixedDeltaTime);
		} else {
			transform.LookAt (target.position + extra);
		}
	}
}
}
