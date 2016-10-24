using UnityEngine;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class NextLevelTrigger : MonoBehaviour {
	void OnTrigger(Collider c){
		if (c.gameObject.gameObject.tag == "Player") {
			GameManager.NewLevel ();
		}
	}
}
