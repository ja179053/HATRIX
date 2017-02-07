using UnityEngine;
using System.Collections;

public class SendPlayerBoxMessage : MonoBehaviour {
	
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
			player.SendMessage ("InRoom2");  
		    Debug.Log ("work");
		}
	}

	void OnTriggerExit () 
	{

	}

}
