using UnityEngine;
using System.Collections;

public class ParticleSound : MonoBehaviour {
	public AudioSource source;
	void Start () {
		// source = GameObject.Find ("ParticleHitAudio").GetComponent<AudioSource> ();
	}

	void OnParticleCollision(GameObject obj) {
		(Object.Instantiate(source) as AudioSource).Play ();
	}
}
