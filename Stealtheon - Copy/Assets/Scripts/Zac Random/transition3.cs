using UnityEngine;
using System.Collections;

public class transition3 : MonoBehaviour {

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
			player.SendMessage ("InRoom1");  
			Debug.Log ("work");
		}
	}
}
