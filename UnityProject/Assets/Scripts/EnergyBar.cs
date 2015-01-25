using UnityEngine;
using System.Collections;

public class EnergyBar : MonoBehaviour {

	#region Fields
	public Texture2D progressBarEmpty; 
	public Texture2D progressBarFull;

	float progress = 0; 
	Vector2 pos;
	Vector2 size = new Vector2(512/2,49/2);
	Rect bgRect, fgRect;
	#endregion
	#region Properties
	#endregion
	#region Methods
	void Start () {
		//int w = progressBarFull.width;
		//int h = progressBarFull.height;

		pos = new Vector2(Screen.width/2 - size.x/2, 2); 
		//size = new Vector2(w,h);
		bgRect = new Rect (pos.x, pos.y, size.x, size.y);
		fgRect = new Rect (pos.x, pos.y, size.x, size.y);
	}

	void OnGUI() {
		GUI.DrawTexture(bgRect, progressBarEmpty);
		fgRect.width = size.x * progress;
	GUI.BeginGroup(fgRect);
		GUI.DrawTexture(new Rect(0, 0, size.x, size.y), progressBarFull);
		GUI.EndGroup();
		/*
		 * 
		 * 
 GUI.DrawTexture(Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
 GUI.BeginGroup(new Rect (pos.x, pos.y, size.x * Mathf.Clamp01(progress), size.y));
 GUI.DrawTexture(new Rect(0, 0, size.x, size.y), progressBarFull);
 GUI.EndGroup();
 */
		// draw the background:
		//GUI.BeginGroup (new Rect (0, 0, size.x, size.y));
		//GUI.Box (new Rect (0,0, size.x, size.y),progressBarEmpty);
		//
		//// draw the filled-in part:
		//GUI.BeginGroup (new Rect (0, 0, size.x * progress, size.y));
		//GUI.Box (new Rect (0,0, size.x, size.y),progressBarFull);
		//GUI.EndGroup ();
		//
		//GUI.EndGroup ();
		
	}

	
	// Update is called once per frame
	void Update () {

	}
	
	public void SetProgress(float curr, float max) {
		progress = Mathf.Clamp(curr/max,0,1);
	}
	#endregion
}
