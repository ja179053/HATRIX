using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans1 : MonoBehaviour {

	public GameObject player;

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	void OnTriggerEnter (Collider Other) 
	{

		if (Other.gameObject.tag == "Player") 
		{   
			player.SendMessage ("Trans");  
			Debug.Log ("work");
		}
	}

}
