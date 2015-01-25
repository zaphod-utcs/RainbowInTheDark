using UnityEngine;
using System.Collections;

public class HideWallsAndDest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    HideTag("Wall");
		HideTag("Destination");
		HideTag("Decoy");
	}

        private void HideTag(string tag) {
             GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
             foreach ( GameObject o in objs ) {
                 o.renderer.enabled = false;
             }
        }

	
	// Update is called once per frame
	void Update () {
	
	}
}
