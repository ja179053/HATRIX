using UnityEngine;
//Only the game manager can be paused
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class GameManager : Title
{
	public static bool paused, options;
	static GameObject pauseScreen;

	public static bool Paused {
		get {
			return paused;
		}
		set {
			paused = value;
			if (paused) {
				Time.timeScale = 0.001f;
			} else {
				Time.timeScale = 1;
			}
			SoundManager.PauseSound (paused);
			pauseScreen.SetActive(paused);
		}
	}

	void Start ()
	{
		ManagerSettings ();
		pauseScreen = GameObject.Find ("Pause Menu");
		pauseScreen.SetActive(false);
		Information.conveyorDirection = -1;
	}
	new void Update(){
		if (Paused) {
			Debug.Log (Information.RoundAway(Information.Enough(Input.GetAxis("Vertical") * 1000, Information.minimumInput)));
			CurrentButton += Information.RoundAway(Information.Enough(Input.GetAxis("Vertical") * 1000, Information.minimumInput));
			if (Input.GetKey (KeyCode.Return)) {
				activeButtons [currentButton].onClick.Invoke ();
			}
		}
	}
	public void Resume ()
	{
		Paused = false;
	}
}
