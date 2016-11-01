using UnityEngine;
using System.Collections;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class NextLevelTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider c){
		if (ActorBehaviour.gotKey) {
			if (c.gameObject.gameObject.tag == "Player") {
				StartCoroutine (Title.NewLevel ());
			}
		}
	}
}
