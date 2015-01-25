using UnityEngine;
using System.Collections;

public enum BurstType {
	REGULAR,
	DEATH
}

public class ParticlesBursts : MonoBehaviour {

	private AudioSource[] _tones;

	ParticleSystem particleSystem = null;
	BlackHole[] blackholes;

	// Use this for initialization
	void Start () {
		print ("Init");
		ParticleSystem[] pss = FindObjectsOfType<ParticleSystem> ();
		foreach (ParticleSystem p in pss) {
			if( p.tag == "MainParticleSystem" ) {
				if (particleSystem != null) {
					throw new UnityException("There must be exactly one particle system");
				}
				particleSystem = pss [0];
			}
		}

		print ("ParticleSystem: " + particleSystem.gameObject.name);

		blackholes = FindObjectsOfType<BlackHole> ();
		foreach (BlackHole blackhole in blackholes) {
			print ("Blackhole: " + blackhole.gameObject.name);
		}

		_tones = GetComponents<AudioSource> ();
	}

	public int maxParticles = 100;

	public float speed = 10;
	public float speedRange = 0;
	public int nParticles = 20;
	public float particleSize = 0.5f, lifetime = 1f;
	public Color color = Color.blue;

	// Update is called once per frame
	void Update () {
		return;

		if (Input.GetKeyDown (KeyCode.Space)) {
			print ("Space");
			//partsys.enableEmission = ! partsys.enableEmission;
			//partsys.Emit(10);

			Burst (BurstType.REGULAR, 0, particleSystem.gameObject.transform.position);

			//ParticleSystem.Particle[] ps = new ParticleSystem.Particle[100];
			//print(partsys.GetParticles(ps));
			//print (ps[0].position);
			//print (ps[0].velocity);
		}
	}

	void FixedUpdate() {
		ParticleSystem.Particle[] ps = new ParticleSystem.Particle[maxParticles];
		int nParticles = particleSystem.GetParticles (ps);
		//print (nParticles);
		//print (ps[0].position);
		//print (ps[0].velocity);
		foreach (BlackHole blackhole in blackholes) {
			bool destHit = false;
			bool decoyHit = false;
			//print ("Blackhole: " + blackhole.transform.position);
			for (int i = 0; i < nParticles; i++) {
				Vector3 diff = ps [i].position - blackhole.transform.position;
				if (diff.magnitude < blackhole.size) {
					//print ("Particle: " + ps [i].position + ", " + ps [i].color);
					Vector3 f = Vector3.MoveTowards (Vector3.zero, diff, blackhole.gravity);
					ps [i].velocity += -f;
					ps [i].velocity *= blackhole.drag;
					ps [i].color = Color.Lerp(ps[i].color, 
					                          new Color(blackhole.colorChange.r, blackhole.colorChange.g, blackhole.colorChange.b), 
					                          blackhole.colorChange.a);
					//print ("1 Particle: " + ps [i].position + ", " + ps [i].color);
					if (blackhole.tag == "Decoy"){
						decoyHit = true;
					};
					if (blackhole.tag == "Destination"){
						destHit = true;
					};
				}
			}
			// play sounds
			if (decoyHit) {
				_tones[7].Play();
			};

			if(destHit){
				_tones[8].Play();
			};
		}
		particleSystem.SetParticles(ps, nParticles);
	}

	public void Burst(BurstType type, float power, Vector3 position) {
		//print ("Burst: " + type + ", " + power + ", " + position);
		switch (type) {
		case BurstType.DEATH:
			for (int i = 0; i < nParticles * 2; i++) {
				Vector3 dir;
				dir = Quaternion.AngleAxis ((float)Random.Range (0f, 360f), new Vector3 (0, 0, 1)) * new Vector3 (0, 1) 
				      * (Random.Range (-speedRange, speedRange) + speed);

				//print ("Particle: " + dir + position);

				particleSystem.Emit (position, dir, particleSize, lifetime, color);
			}
			break;


		case BurstType.REGULAR:
				for (int i = 0; i < nParticles; i++) {
					Vector3 dir;
					dir = Quaternion.AngleAxis (i * 360.0f / nParticles, new Vector3 (0, 0, 1)) * new Vector3 (0, 1) 
						* (Random.Range (-speedRange, speedRange) + speed);
	
					//print ("Particle: " + dir + position);
	
					particleSystem.Emit (position, dir, particleSize, lifetime, color);
				}
			break;
		}
	}
}
