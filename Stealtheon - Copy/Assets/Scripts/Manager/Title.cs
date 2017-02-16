using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
//Controls the level loaded. Exits on scene 0.
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public class Title : Singleton<Title>
{
	protected Title(){}
	enum TitleState{
		Main,
		Levels
		}
	TitleState ts;
	GameObject optionsMenu;
	protected static int currentLevel = 0;
	void Start(){
		currentLevel = 0;
		ts = TitleState.Main;
		if (lastLevel == null) {
			try{
				lastLevel = PlayerPrefs.GetInt("LastLevel");
			} catch {
				GameObject.Find ("ContinueButton").SetActive (false);
			}
		}
		ManagerSettings ();
	}
	protected static SoundManager sa;
	protected void ManagerSettings(){
		sa = FindObjectOfType<SoundManager> ();
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		activeButtons = FindObjectsOfType<Button> ();
		optionsMenu = GameObject.Find ("Options Menu");
		icon = buttonIcon;
		Actor.ActorMovement.pcMode = !Application.isMobilePlatform;
		if (!Actor.ActorMovement.pcMode) {
			Application.runInBackground = false;
			Screen.autorotateToPortrait = false;
			Screen.autorotateToPortraitUpsideDown = false;
			Screen.autorotateToLandscapeLeft = true;
		}
	}
	static Button[] defaultButtons;
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Quit ();
		} else if (!Input.GetMouseButton (0)) {
			if (Input.anyKeyDown) {
				LoadNewLevel (4);
			}
		}
	}
	public void LoadNewLevel(float waitTime = 0){
		StartCoroutine(NewLevel (waitTime));
		StartCoroutine (LoadingScreen.AsynchronousLoad (currentLevel,4));
	}
	int lastLevel;
	public void Continue(){
		StartCoroutine(NewLevel(4, lastLevel));
	}
	//Either advances or resets to title screen (Can be adapted for level selection).
	public static IEnumerator NewLevel (float waitTime = 0, int nextLevel = -1)
	{
		SoundManager.PlaySource (true);
		yield return new WaitForSeconds (waitTime);
		if ((nextLevel == -1) && ((currentLevel + 1) < SceneManager.sceneCountInBuildSettings)) {
			currentLevel = currentLevel + 1;
		} else if (nextLevel != -1){
			currentLevel = nextLevel;
			} else {
			currentLevel = 0;
		}
		SceneManager.LoadScene (currentLevel);
	}

	public void Quit ()
	{
		PlayerPrefs.SetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);
		Debug.Break ();
		Application.Quit ();
	}

	protected static Button[] activeButtons;
	public Image buttonIcon;
	static Image icon;
	protected static int currentButton = 0;
	static bool inputting = false;
	protected int CurrentButton{
		get {
			return currentButton;
		} set {
			if (!inputting) {
				inputting = true;
				value = (int)Mathf.Repeat (value, activeButtons.Length);
				FindObjectOfType<GameManager>().StartCoroutine(UpdateIcon ());
				currentButton = value;
			}
		}
	}
	//Only to be used for the options menu. (in-game).
	static IEnumerator UpdateIcon ()
	{
		yield return new WaitForSeconds (0.001f);
		icon.transform.position = new Vector2 (icon.transform.position.x, activeButtons [currentButton].transform.position.y);
		inputting = false;
	}

	public void Options ()
	{
		foreach (Button b in defaultButtons) {
			b.gameObject.SetActive (optionsMenu.activeSelf);
		}
		optionsMenu.SetActive (!optionsMenu.activeSelf);
	}
}
