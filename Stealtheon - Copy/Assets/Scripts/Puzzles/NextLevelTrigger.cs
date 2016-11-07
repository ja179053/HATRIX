using UnityEngine;
using System.Collections;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class NextLevelTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider c){
		if (ActorBehaviour.gotKey) {
			ActorBehaviour.gotKey = false;
			if (c.gameObject.gameObject.tag == "Player") {
				StartCoroutine (Title.NewLevel ());
			}
		}
	}
}
