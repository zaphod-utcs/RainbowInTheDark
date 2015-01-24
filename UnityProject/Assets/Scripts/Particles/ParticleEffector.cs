using UnityEngine;
using System.Collections;

public class ParticleEffector : MonoBehaviour {
	public float hardness = 0.9f;
	public Color colorChange = Color.clear;

	void OnParticleCollision(GameObject obj) {
		//print ("collide");
		ParticleSystem particleSystem = obj.GetComponent<ParticleSystem> ();
		ParticleSystem.CollisionEvent[] colls = new ParticleSystem.CollisionEvent[100];
		int nColls = particleSystem.GetCollisionEvents (gameObject, colls);
		/*for (int i = 0; i < nColls; i++) {
			colls[i].
		}*/
	}
}
