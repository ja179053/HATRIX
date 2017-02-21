using UnityEngine;
using System.Collections;

public class MinigamesTitle : MonoBehaviour {
	public GameObject minigames, minigamesArt;
	bool showNow;
	// Use this for initialization
	void Start () {
		zero = Quaternion.Euler (Vector3.zero);
		minigames.SetActive (false);
	}
	static Quaternion zero, temp;
	void Update(){
		if (showNow) {
			minigamesArt.transform.rotation = Quaternion.Lerp(minigamesArt.transform.rotation, zero, Time.deltaTime);//Quaternion.Lerp (minigamesArt.transform.rotation, zero, Time.deltaTime);
	//		minigamesArt.transform.position = Vector3.Lerp
		} else if (temp != null) {
			minigamesArt.transform.rotation = Quaternion.Lerp(minigamesArt.transform.rotation, temp, Time.deltaTime);
		}
	}
	public void ShowMinigames(bool show){
		if (show) {
			temp = minigamesArt.transform.rotation;
		//	minigamesArt.transform.rotation = zero;//Quaternion.Lerp (minigamesArt.transform.rotation, zero, Time.deltaTime);
		} else {
		//	minigamesArt.transform.rotation = temp;
		}
		minigames.SetActive (show);
		showNow = show;
	}
	public void LoadMinigame(string levelName){
		StartCoroutine(Title.NewLevel (5, -1, levelName));
	}
}
