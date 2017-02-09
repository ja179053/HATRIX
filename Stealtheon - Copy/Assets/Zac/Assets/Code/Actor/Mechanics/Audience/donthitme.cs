using UnityEngine;
using System.Collections;
[AuthorAttribute ("Zac", TeamRole.Designer)]
public class donthitme : MonoBehaviour {

	public GameObject audience;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.tag == "card")
		{
			doSomething ();
		}
	}

	void doSomething () 
	{
		Debug.Log ("derp2");
		audience.SendMessage ("nay");
	}

}
