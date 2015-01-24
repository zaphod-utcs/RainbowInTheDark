using UnityEngine;
using System.Collections;

public class ParticlesBursts : MonoBehaviour {
	ParticleSystem partsys;
	GameObject partsysobj, blackhole;

	// Use this for initialization
	void Start () {
		print ("Init");
		partsysobj = GameObject.Find ("Test Particle System");
		blackhole = GameObject.Find ("BlackHole");
		partsys = partsysobj.GetComponent<ParticleSystem> ();
	}

	public float speed = 10;
	public float speedRange = 0;
	public int nParticles = 20;
	public float particleSize = 0.5f, lifetime = 1f;
	public Color color = Color.blue;

	public float blackholeSize = 1;
	public float blackholePull = 1;
	public float blackholeDrag = 0.9f;


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			print ("Space");
			//partsys.enableEmission = ! partsys.enableEmission;
			//partsys.Emit(10);

			Burst (partsysobj.transform.position);

			//ParticleSystem.Particle[] ps = new ParticleSystem.Particle[100];
			//print(partsys.GetParticles(ps));
			//print (ps[0].position);
			//print (ps[0].velocity);
		}
	}

	void FixedUpdate() {
		ParticleSystem.Particle[] ps = new ParticleSystem.Particle[100];
		int nParticles = partsys.GetParticles (ps);
		//print (ps[0].position);
		//print (ps[0].velocity);
		for( int i = 0; i < nParticles; i++){
			Vector3 diff = ps[i].position - blackhole.transform.position;
			if(diff.magnitude < blackholeSize) {
				Vector3 f = Vector3.MoveTowards(Vector3.zero, diff, blackholePull);

				ps[i].velocity += -f;
				ps[i].velocity *= blackholeDrag;
			}
		}
		partsys.SetParticles(ps, nParticles);
	}

	public void Burst(Vector3 position) {
		for (int i = 0; i < nParticles; i++) {
			Vector3 dir;
			if(false)
				dir = Quaternion.AngleAxis((float)Random.Range(0f, 360f), new Vector3(0,0,1)) * new Vector3(0, 1) 
					* (Random.Range(-speedRange, speedRange) + speed);
			else
				dir = Quaternion.AngleAxis(i * 360.0f / nParticles, new Vector3(0,0,1)) * new Vector3(0, 1) 
					* (Random.Range(-speedRange, speedRange) + speed);
			
			//print ("Particle: " + dir);
			
			partsys.Emit(position, dir, particleSize, lifetime, color);
		}
	}
}
