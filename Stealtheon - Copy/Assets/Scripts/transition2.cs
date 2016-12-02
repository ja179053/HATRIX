using UnityEngine;
using System.Collections;

public class transition2 : MonoBehaviour {

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
			player.SendMessage ("InRoom4");  
			Debug.Log ("work");
		}
	}
}
