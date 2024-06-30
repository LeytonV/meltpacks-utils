using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityUtils.Effects
{

	/// <summary>
	/// Allows all child audio sources and particlesystems to be played at the same time from one method call, without directly referencing them.
	/// </summary>
	public class EffectGroup : MonoBehaviour
	{
		ParticleSystem[] particles;
		AudioSource[] sounds;
		void Start()
		{
			particles = GetComponentsInChildren<ParticleSystem>();
			sounds = GetComponentsInChildren<AudioSource>();
		}
		public void Play()
		{
			foreach (ParticleSystem sys in particles)
				sys.Play();

			foreach (AudioSource src in sounds)
				src.PlayOneShot(src.clip);
		}
	}
}