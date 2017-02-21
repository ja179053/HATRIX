using UnityEngine;
using System.Collections;

public class RandomBackgroundColour : MonoBehaviour
{
	public float speed = 1;
	// Use this for initialization
	void Update ()
	{
	//	Debug.Log ("running");
		//RenderSettings.ambientSkyColor
		RenderSettings.ambientSkyColor = Color.Lerp (RenderSettings.ambientSkyColor, RandomColor(RenderSettings.ambientSkyColor, 0.1f * speed), Time.deltaTime * speed);
	}

	Color RandomColor (Color c, float difference)
	{
		difference = Mathf.Clamp (difference, 0, 1);
		return new Vector4 (Random.Range (c.r - difference, c.r + difference), Random.Range (c.g - difference, c.g + difference), Random.Range (c.b - difference, c.b + difference));
	}
}
