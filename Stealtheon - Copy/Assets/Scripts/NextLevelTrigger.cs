using UnityEngine;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class NextLevelTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider c){
		if (c.gameObject.gameObject.tag == "Player") {
			Title.NewLevel ();
		}
	}
}
