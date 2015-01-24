using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

		public ParticleSystem particleSystem;

		void Awake()
		{
				particleSystem = gameObject.GetComponent<ParticleSystem>();
		}

		void Start()
		{
				particleSystem.Emit(particleSystem.maxParticles);
				ParticleSystem.Particle[] particleArray = new ParticleSystem.Particle[particleSystem.maxParticles];
				int particles = particleSystem.GetParticles(particleArray);
				for (int i = 0; i < particles; i++)
				{
						Vector3 vel = particleArray[i].velocity;
						vel.z = 0;
						particleArray[i].velocity = vel;
				}
				particleSystem.SetParticles(particleArray, particles);

		}
}
