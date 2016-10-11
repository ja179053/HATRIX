using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit ray;
		if (Physics.Raycast(transform.position + (transform.forward * Information.conveyorDirection), Vector3.down, out ray, 1)) {
			if (ray.collider.tag == "Conveyor") {
				transform.position += transform.forward * Information.conveyorDirection * Information.conveyorSpeed;
			}
		}
	}
}
