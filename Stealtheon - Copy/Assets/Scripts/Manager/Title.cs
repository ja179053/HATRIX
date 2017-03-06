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
	static string username;
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
		UserSettings ();
	}
	protected static SoundManager sa;
	protected void ManagerSettings(){
		sa = FindObjectOfType<SoundManager> ();
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		activeButtons = FindObjectsOfType<Button> ();
		optionsMenu = GameObject.Find ("Options Menu");
		icon = buttonIcon;
		Actor.ActorMovement.pcMode = !Application.isMobilePlatform;
	//	Debug.Log ("Working");
		if (!Actor.ActorMovement.pcMode) {
			Application.runInBackground = false;
			Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
			Screen.autorotateToLandscapeLeft = true;
			Screen.orientation = ScreenOrientation.Landscape;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}
	}
	static InputField iField;
	void UserSettings(){
		try{
		iField = FindObjectOfType<InputField> ();
		iField.gameObject.SetActive (username == null);
		} catch {
		}
	}
	public void AddUserName(){
		username = iField.textComponent.text;
		Debug.Log (username);
		iField.gameObject.SetActive (false);
	}
	static Button[] defaultButtons;
	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Quit ();
		} else if (!Input.GetMouseButton (0)) {
			if (Input.anyKeyDown) {
			//	LoadNewLevel (4);
			}
	//		AddUserName () = iField.onEndEdit;
		}
	}
	public void LoadNewLevel(float waitTime = 0){
		StartCoroutine (NewLevel (waitTime, -1));
	}
	public void RestartLevel(){
		StartCoroutine (NewLevel (0, SceneManager.GetActiveScene().buildIndex));
	}
	public void ExitToMenu(){
		StartCoroutine (NewLevel ());
	}
	int lastLevel;
	public void Continue(){
		StartCoroutine(NewLevel(4, lastLevel));
	}
	//Either advances or resets to title screen (Can be adapted for level selection).
	public static IEnumerator NewLevel (float waitTime = 0, int nextLevel = -1, string s = "")
	{
		SoundManager.PlaySource (true);
		if (s == "") {
			if ((nextLevel == -1) && ((currentLevel + 1) < SceneManager.sceneCountInBuildSettings)) {
				currentLevel = currentLevel + 1;
			} else if (nextLevel != -1) {
				currentLevel = nextLevel;
			} else {
				currentLevel = 0;
			}
		} /*else {
		//	currentLevel = SceneManager.GetSceneByName (s).buildIndex;
			Scene c = SceneManager.GetSceneByName ("mysticlevel");
			currentLevel = c.buildIndex;

			if (!c.IsValid ()) {
				Debug.Log (SceneManager.sceneCountInBuildSettings);
				currentLevel = SceneManager.sceneCountInBuildSettings - 1;
				Scene d = SceneManager.get (currentLevel);
				Debug.Log(d.name);
			}
			if (c != null) {
				Debug.Log (c.IsValid());
			} else {
				Debug.LogError ("scene is null");
			}
		}*/
		//Debug.Log (SceneManager.GetActiveScene ().name);//(currentLevel));
		Instance.StartCoroutine (LoadingScreen.AsynchronousLoad (currentLevel,waitTime));
		yield return new WaitForSeconds (waitTime);
		if (s == "") {
			SceneManager.LoadScene (currentLevel);
		} else {
			SceneManager.LoadScene (s);
		}
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
