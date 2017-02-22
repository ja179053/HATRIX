using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;
public class ButtonHover : Singleton<ButtonHover> {
	Vector3 startPos, endPos;
	Button activeButton;
	public float speed = 1;
	public void Activate(Button b){
		activeButton = b;
		b.transform.localScale = new Vector3 (2, 2, 1);
		startPos = b.transform.position;
		endPos = startPos + (Vector3.right * speed);
	//	if (pos ) {
	//		pos = b.transform.localPosition;
	//	}
	}
	void Update(){
		Wiggle ();	
	}
	void Wiggle(){
		if(activeButton != null){
	//		activeButton.transform.position = Vector3.Lerp (startPos, endPos, Mathf.SmoothStep (0, speed, Mathf.SmoothStep (0, speed, Time.time)));
			activeButton.transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / speed) * speed);
		}
	}
	public void Deactivate(Button b){
		b.transform.localScale = new Vector3 (1, 1, 1);
		b = null;
	}
}
