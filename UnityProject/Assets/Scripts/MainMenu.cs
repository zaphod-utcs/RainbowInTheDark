using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	#region Fields
	public GameObject bgStart;
	public GameObject bgCtrl;
	public GUISkin myGuiSkin;

	const int buttonWidth = 387;
	const int buttonHeight = 102;
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
	Rect rect1, rect2;
	#endregion

	void Start() {
		//guiTextureStart = bgStart.GetComponent<guiTextureStart>();
		//guiTextureControls = bgCtrl.GetComponent<guiTextureControls>();

		rect1 = new Rect(Screen.width/2 - buttonWidth/2, 0, buttonWidth/2, buttonHeight);
		rect2 = new Rect(0,0,buttonWidth, buttonHeight);
		
		startButtonRect = new Rect(0,startY,buttonWidth,buttonHeight);
		controlsButtonRect = new Rect(780,startY,buttonWidth,buttonHeight);
		backButtonRect = new Rect(0,startY,buttonWidth,buttonHeight);
		Debug.Log("MainMenu::Start() startButtonRect: " + startButtonRect);
		
		
	}
	void OnGUI() {

		//GUI.Box (new Rect (0,0,100,50), "Top-left");
		//GUI.Box (new Rect (Screen.width - 100,0,100,50), "Top-right");
		//GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
		//
		//GUI.Box (new Rect (Screen.width - buttonWidth/2,
		//                   Screen.height*2/3 - buttonHeight/2,
		//                   buttonWidth,
		//                   buttonHeight), "---");
        //
		
		//GUI.Box (new Rect (244,280,144,32), "START");
		//GUI.Box (new Rect (244,324,144,32), "CONTROLS");
		GUI.skin = myGuiSkin;

		if (isStartMenu) {
			DisplayStartMenu();
		}
		else {
			DisplayControlsMenu();
		}
	}
	void DisplayStartMenu() {
		
		//rect1 = new Rect(0, 280, buttonWidth/4, buttonHeight/4);
		//GUI.BeginGroup(rect1);
		//GUI.Button(rect2,"","StartButton");
		//GUI.EndGroup();
		
		//rect1.y = buttonHeight;
		//GUI.Button(rect1,"","ControlsButton");
		//GUI.EndGroup();
		
		if(GUI.Button(new Rect (244,280,144,32),"","StartButton")) {
			Debug.Log ("Start clicked");
			Application.LoadLevel("Level 1");
		}
		
		if(GUI.Button(new Rect(244,324,144,32),"", "ControlsButton")) {
			Debug.Log ("Controls clicked");
			ToggleDisplays();
		}
	}
	void DisplayControlsMenu(){
		if(GUI.Button(new Rect (250,332,144,32),"","BackButton")) {
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
