using UnityEngine;
using System.Collections;

public class AnimatoNoWrap : MonoBehaviour {
	private SpriteRenderer sprite;
	private float startTime;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
				startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time - startTime;
		if (t > 1) {
			sprite.color = new Color (1, 1, 1, 1 - (t - 1));
		}
	}
}
