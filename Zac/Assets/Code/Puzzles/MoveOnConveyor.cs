using UnityEngine;
//This script moves an object when placed on a conveyor belt using raycasting. Conveyor information is pre-stored in Information.
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class MoveOnConveyor : MonoBehaviour
{	
	void Update ()
	{
		RaycastHit ray;
		if (Physics.Raycast (transform.position + (transform.forward * Information.conveyorDirection), Vector3.down, out ray, 1)) {
			if (ray.collider.tag == "Conveyor") {
				transform.position += transform.forward * Information.conveyorDirection * Information.conveyorSpeed;
			}
		}
	}
}
