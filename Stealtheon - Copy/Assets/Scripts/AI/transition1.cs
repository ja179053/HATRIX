using UnityEngine;
using System.Collections;
[AuthorAttribute("Zac", TeamRole.Designer)]
public class transition1 : MonoBehaviour {

	public GameObject player;
	//JJS EDIT- USE THE SEND MESSAGE TO STRING TO CHANGE THE METHOD YOU CALL EVERYTIME YOU COLLIDE WITH THE PLAYER, USING THE SAME SCRIPT.
	public string sendMessageTo = "Box 1";
	void Start () 
	{
		
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider Other) 
	{
		
		if (Other.gameObject.tag == "Player") 
		{  player.SendMessage (sendMessageTo); }
	}
}
