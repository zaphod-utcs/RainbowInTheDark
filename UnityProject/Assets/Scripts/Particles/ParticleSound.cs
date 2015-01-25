using UnityEngine;
using System.Collections;

public class ParticleSound : MonoBehaviour {
	public AudioSource[] source;
	void Start () {
		source = GetComponents<AudioSource> ();
	}

	void OnParticleCollision(GameObject obj) {
		source[Random.Range(0,6)].Play();
	}
}
