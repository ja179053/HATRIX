using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
	public static bool zoom, zooming;
	public static int zoomDist = 2, normalDist = 8, zoomSpeed = 1;

	static int TargetZoom ()
	{
		if (zooming) {
			if (zoom) {
				return zoomDist;
			} else {
				return normalDist;
			}
		}
		return Mathf.RoundToInt(Camera.main.orthographicSize);
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Z) || zooming) {
			Zoom (!zoom);
		}
	}

	public static void Zoom (bool b)
	{
		if (zoom != b) {
			if (!zooming) {
				zoom = b;
				zooming = true;
			}
			zooming = (!(Mathf.RoundToInt(Camera.main.orthographicSize) == TargetZoom ()));
		}
		//	Camera.main.orthographicSize = TargetZoom ();
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, TargetZoom (), Time.deltaTime * zoomSpeed);
	}
}
