using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScreen : MonoBehaviour {
	static Image myImage;
	// Use this for initialization
	void Start () {
	//	DontDestroyOnLoad (this.gameObject);
		myImage = GetComponent<Image> ();
		myImage.color = new Vector4 (myImage.color.r, myImage.color.g, myImage.color.b, 0);
	}
	
	// Update is called once per frame
	public static IEnumerator AsynchronousLoad (int scene, float time) {
		AsyncOperation ao = SceneManager.LoadSceneAsync (scene);
		myImage.color = new Vector4 (myImage.color.r, myImage.color.g, myImage.color.b, 1);
		ao.allowSceneActivation = false;
		yield return new WaitForSeconds (time);
		while (!ao.isDone) {
			if (ao.progress == 0.9f) {
			//	Debug.Log ("loaded");
			//	if (Input.anyKey) {
					ao.allowSceneActivation = true;
			//	}
			}
		//	myImage.color = new Vector4 (myImage.color.r, myImage.color.g, myImage.color.b, 0);
			yield return new WaitForEndOfFrame();
		}
	}
}
