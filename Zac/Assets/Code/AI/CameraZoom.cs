using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
	public bool zoom, zooming;
	public float zoomDist, normalDist, zoomSpeed;
	float targetZoom;
	float Targetzoom {
		get {
			return targetZoom;
		}
		set {
			targetZoom = value;
			zooming = true;
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (zoom) {
			targetZoom = zoomDist;
		} else {
			targetZoom = normalDist;
		}
		if (zooming) {
			Zoom ();
		}
	}

	void Zoom ()
	{
		zooming = true;
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
		if (Camera.main.orthographicSize == Targetzoom) {
			zooming = false;
		}
	}
}
