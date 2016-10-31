using UnityEngine;
using System.Collections;

[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class Background : MonoBehaviour {
	public int length = 1;
	public float blockWidth = 1;
	public Material m;
	// Use this for initialization
	void Start () {
		float i = 0;
		while (i < length) {
		//	int cubeSize = (int)Random.Range (1, blockWidth);
			GameObject g = GameObject.CreatePrimitive (PrimitiveType.Cube);
			g.GetComponent<Renderer> ().material = m;
			float blockHeight = blockWidth * Random.Range(1,3) / 2;
			g.transform.localScale = new Vector3 (blockWidth, blockHeight, blockWidth);
			g.transform.position = transform.position + (transform.right * (i * blockHeight));
			int boolean = Random.Range (0, 1);
			if (boolean == 0) {
				boolean = -1;
			}
			g.transform.localPosition += Vector3.up * (int)blockHeight * blockHeight;
			i += blockWidth;
		}
	}
}
