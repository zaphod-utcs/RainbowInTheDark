using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	#region Fields
	const int buttonWidth = 355;
	const int buttonHeight = 75;
	Rect buttonRect;
	Rect startButtonRect;
	Rect controlsButtonRect;
	Rect backButtonRect;
	#endregion

	void Start() {
		startButtonRect = new Rect(740,780,buttonWidth,buttonHeight);
		controlsButtonRect = new Rect(780,780,buttonWidth,buttonHeight);
		backButtonRect = new Rect(795,867,buttonWidth,buttonHeight);
	}
	void OnGUI()
	{

		// Draw a button to start the game
		if(GUI.Button(startButtonRect,""))
		{
			Debug.Log ("Start clicked");
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			//Application.LoadLevel("Stage1");
		}
		
		if(GUI.Button(controlsButtonRect,""))
		{
			Debug.Log ("Controls clicked");
			// On Click, load the first level.
			// "Stage1" is the name of the first scene we created.
			//Application.LoadLevel("Stage1");
		}
	}
}
