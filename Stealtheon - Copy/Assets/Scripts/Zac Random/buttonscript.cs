using UnityEngine;
using System.Collections;

public class buttonscript : MonoBehaviour {

	public GameObject wall;
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
		Debug.Log ("derp");
		wall.SetActive (false);
		audience.SendMessage ("yay");
	}

}
