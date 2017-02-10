using UnityEngine;
using System.Collections;

namespace Tools{
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class Instantiator : MonoBehaviour
{
	public string keyboardButton = "space";
	public Vector3 forceToAdd,extraRotation;
	public float rotationAngleRange;
	public GameObject instantiatedObject;
	int i;
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (keyboardButton)) {
			Quaternion initialRotation = Quaternion.Euler (new Vector3 (Random.Range(-rotationAngleRange, rotationAngleRange),Random.Range(-rotationAngleRange, rotationAngleRange),Random.Range(-rotationAngleRange, rotationAngleRange)));
			GameObject g = GameObject.Instantiate (instantiatedObject, transform.position, Quaternion.identity * initialRotation * Quaternion.Euler(extraRotation)) as GameObject;
			g.GetComponent<Rigidbody> ().AddForce (forceToAdd);
			i++;
		}
		if (Input.GetKey (KeyCode.P)) {
			Debug.Log (i);
		}
	}
}
}
