using UnityEngine;
using System.Collections;

public class Monochrome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// MeshFilter component
		Mesh mesh = GetComponent<MeshFilter>().mesh;

		// get the vertex count for the objet
		int vCount = mesh.vertexCount ;

		// create an array of Colors with the same length
		Color[] new_vcolor = new Color[vCount];
		for (int i = 0 ; i < vCount ; ++i)
		{
			// set the color for the corresponding vertex index in the array
			// we choose a gray color with an alpha of 1
			new_vcolor[i] = new Color (0.5f,0.5f,0.5f,1) ; 
		}

		// replace the current vertex color array 
		//(white everywhere if it was untouched) 
		// with the newly created one
		mesh.colors = new_vcolor ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
