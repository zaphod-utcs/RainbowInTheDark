using UnityEngine;
using System.Collections;

public class ParticlesBursts : MonoBehaviour {
	ParticleSystem partsys;
	GameObject partsysobj;

	// Use this for initialization
	void Start () {
		print ("Init");
		partsysobj = GameObject.Find ("Test Particle System");
		partsys = partsysobj.GetComponent<ParticleSystem> ();
	}

	static float speed = 10;
	static float speedRange = 0;
	static int nParticles = 20;
	static Color color = Color.blue;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			print ("Space");
			//partsys.enableEmission = ! partsys.enableEmission;
			//partsys.Emit(10);

			for (int i = 0; i < nParticles; i++) {
				Vector3 dir;
				if(false)
					dir = Quaternion.AngleAxis((float)Random.Range(0f, 360f), new Vector3(0,0,1)) * new Vector3(0, 1) 
						* (Random.Range(-speedRange, speedRange) + speed);
				else
					dir = Quaternion.AngleAxis(i * 360.0f / nParticles, new Vector3(0,0,1)) * new Vector3(0, 1) 
						* (Random.Range(-speedRange, speedRange) + speed);

				//print ("Particle: " + dir);

				partsys.Emit(partsysobj.transform.position, dir, 0.5, 0.5f, color);
			}

			ParticleSystem.Particle[] ps = new ParticleSystem.Particle[100];
			//print(partsys.GetParticles(ps));
			//print (ps[0].position);
			//print (ps[0].velocity);
		}
	}
}
