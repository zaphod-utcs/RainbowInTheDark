using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	#region Fields
	public GameObject bgStart;
	public GameObject bgCtrl;

	const int buttonWidth = 355;
	const int buttonHeight = 75;
	const int startX = 740;
	const int startY = 780;
	const int backX = 795;
	const int backY = 867;
	Rect buttonRect;
	Rect startButtonRect;
	Rect controlsButtonRect;
	Rect backButtonRect;
	bool isStartMenu = true;
	GUITexture guiTextureStart;
	GUITexture guiTextureControls;
	#endregion

	void Start() {
		//guiTextureStart = bgStart.GetComponent<guiTextureStart>();
		//guiTextureControls = bgCtrl.GetComponent<guiTextureControls>();
		startButtonRect = new Rect(0,startY,buttonWidth,buttonHeight);
		controlsButtonRect = new Rect(780,startY,buttonWidth,buttonHeight);
		backButtonRect = new Rect(0,startY,buttonWidth,buttonHeight);
		Debug.Log("MainMenu::Start() startButtonRect: " + startButtonRect);
	}
	void OnGUI() {

		GUI.Box (new Rect (0,0,100,50), "Top-left");
		GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
		GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
		
		GUI.Box (new Rect (Screen.width - buttonWidth/2,
		                   Screen.height*2/3 - buttonHeight/2,
		                   buttonWidth,
		                   buttonHeight), "---");
		
		if (isStartMenu) {
			DisplayStartMenu();
		}
		else {
			DisplayControlsMenu();
		}
	}
	void DisplayStartMenu() {
		if(GUI.Button(new Rect (0,0,100,50),"Start")) {
			Debug.Log ("Start clicked");
			Application.LoadLevel("Level 1");
		}
		
		if(GUI.Button(new Rect(Screen.width - 100,0,100,50),"Controls")) {
			Debug.Log ("Controls clicked");
			ToggleDisplays();
		}
	}
	void DisplayControlsMenu(){
		if(GUI.Button(new Rect (0,0,100,50),"Back")) {
			Debug.Log ("Back clicked");
			ToggleDisplays();
		}
	}
	void ToggleDisplays() {
		isStartMenu = !isStartMenu;
		bgStart.SetActive(isStartMenu);
		bgCtrl.SetActive(!isStartMenu);
		//bgStart.enabled = !bgStart.enabled;
		//bgCtrl.enabled = !bgCtrl.enabled;
	}
}
