using UnityEngine;
using System.Collections;

public class transition1 : MonoBehaviour {

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
			player.SendMessage ("InRoom3");  
			Debug.Log ("work");
		}
	}
}
