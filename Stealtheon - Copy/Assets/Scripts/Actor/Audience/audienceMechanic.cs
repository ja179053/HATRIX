using UnityEngine;
using System.Collections;

public class audienceMechanic : MonoBehaviour {

	public GameObject tick;
	public GameObject cross;

	public float maxTime = 2f;
	public float countdown = 1f;

	public bool liking;
	public bool disliking;

	void Start () 
	{
		countdown = maxTime;
		liking = false;
		disliking = false;
	}

	void Update () 
	{
		if (liking == true) 
		{
			tick.SetActive (true);
			countdown -= Time.deltaTime;
		}

		if (disliking == true) 
		{
			cross.SetActive (true);
			countdown -= Time.deltaTime;
		}

		if (countdown <= 0)
		{
			liking = false;
			disliking = false;
			tick.SetActive (false);
			cross.SetActive (false);
		}

	}

	void yay () 
	{
		countdown = maxTime;
		liking = true;
	}

	void nay () 
	{
		countdown = maxTime;
		disliking = true;
	}

}
