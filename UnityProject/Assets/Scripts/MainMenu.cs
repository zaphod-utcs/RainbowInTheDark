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
	bool isStartMenu = true;
	GUITexture guiTextureStart;
	GUITexture guiTextureControls;
	Rect rectStart, rectControls, rectBack;
	Vector2 relPosBtn1;
	Vector2 relPosBtn2;
	Vector2 relPosBtn3;
	Vector2 scaleBtn;
	Vector2 scaleBtn3;
	#endregion

	void Start() {

		relPosBtn1.x = 778f/1920f; //0.4052
		relPosBtn1.y = 736f/1200f; //0.6133
		relPosBtn2.x = relPosBtn1.x;
		relPosBtn2.y = 850f/1200f;
		scaleBtn.x = 362f/1920f * 1.1f;
		scaleBtn.y = 76f/1200f;

		relPosBtn3.x = 792f/1920f; 
		relPosBtn3.y = 864f/1200f; 
		scaleBtn3.x = 364f/1920f;
		scaleBtn3.y = 78f/1200f;

		//Debug.Log("MainMenu::Start() startButtonRect: " + startButtonRect);
		//Debug.Log ("Screen.width = " + Screen.width);
		//Debug.Log ("Screen.height = " + Screen.height);
		//Debug.Log ("Screen.width * ratioX = " + Screen.width * ratioX);

	}
	void OnGUI() {

		GUI.skin = myGuiSkin;

		if (isStartMenu) {
			DisplayStartMenu();
		}
		else {
			DisplayControlsMenu();
		}
	}
	void DisplayStartMenu() {

		rectStart = new Rect(Screen.width * relPosBtn1.x, Screen.height * relPosBtn1.y, Screen.width*scaleBtn.x,Screen.width*scaleBtn.y);
		rectControls = new Rect(Screen.width * relPosBtn2.x, Screen.height * relPosBtn2.y, Screen.width*scaleBtn.x,Screen.width*scaleBtn.y);

		if (GUI.Button (rectStart,"","StartButton")){
			//Debug.Log ("Start clicked");
			Application.LoadLevel("Level 1");
		}
		
		if(GUI.Button(rectControls,"", "ControlsButton")) {
			//Debug.Log ("Controls clicked");
			ToggleDisplays();
		}
	}
	void DisplayControlsMenu(){
		rectBack = new Rect(Screen.width * relPosBtn3.x, Screen.height * relPosBtn3.y, Screen.width*scaleBtn3.x,Screen.width*scaleBtn3.y);

		if(GUI.Button(rectBack,"","BackButton")) {
			//Debug.Log ("Back clicked");
			ToggleDisplays();
		}
	}
	void ToggleDisplays() {
		isStartMenu = !isStartMenu;
		bgStart.SetActive(isStartMenu);
		bgCtrl.SetActive(!isStartMenu);
	}
}
