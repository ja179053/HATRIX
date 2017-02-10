using UnityEngine;
using System.Collections;

public class transitionCode : MonoBehaviour {
	
	public GameObject player;


	void Start () 
	{
	
	}

	void Update () {
	
	}

	void OnTriggerEnter (Collider Other) 
	{

		if (Other.gameObject.tag == "Player") 
		{   
			player.SendMessage ("Box1");  
		}
	}

	void OnTriggerExit () 
	{

	}

}
