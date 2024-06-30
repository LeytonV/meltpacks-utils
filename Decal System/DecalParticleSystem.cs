using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeltUtils.Decals
{
	public class DecalParticleSystem : MonoBehaviour
	{
		public Material decalMaterial;
		public ParticleSystem sys;
		public float particleSize;
		List<ParticleCollisionEvent> collisionEvents;
		// Start is called before the first frame update
		void Start()
		{
			collisionEvents = new List<ParticleCollisionEvent>();
		}

		// Update is called once per frame
		void Update()
		{
		}

		void OnParticleCollision(GameObject other)
		{

			int numCollisionEvents = sys.GetCollisionEvents(other, collisionEvents);

			for (int i = 0; i < numCollisionEvents; i++)
			{
				ParticleCollisionEvent col = collisionEvents[i];
				DecalManager.instance.AddQuad(decalMaterial, col.intersection, col.normal, Vector3.one * particleSize, Random.Range(0f, 360f));
			}
		}
	}
}