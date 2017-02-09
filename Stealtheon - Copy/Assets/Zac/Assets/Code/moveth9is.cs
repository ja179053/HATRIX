using UnityEngine;
using System.Collections;

public class moveth9is : MonoBehaviour {

	public GameObject C2;
	public GameObject C2Clone;
	public GameObject MirrorController;
	public bool doit;

	// Use this for initialization
	void Start () 
	{
		C2 = GameObject.Find ("C2");
		C2Clone = GameObject.Find ("C2Clone");
		doit = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (doit == true) 
		{
			Debug.Log ("derp");
			C2.SetActive (false);
			C2Clone.SetActive (true);
			MirrorController.SendMessage ("moveSideC2");
			doit = false;
		}

	}

	void OnTriggerEnter (Collider Other)
	{
		if (Other.gameObject.tag == "Player")
		{
			doit = true;
		}
	}
}
