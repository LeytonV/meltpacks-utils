using UnityEngine;

namespace MUnityUtils.Effects
{
	/// <summary>
	/// Similar to EffectGroup, but includes functionality for randomised sound clips
	/// </summary>
	public class WeaponFX : MonoBehaviour
	{
		[HideInInspector] public ParticleSystem particles;
		[Header("This will play all particlesystems and audio sources parented to it.")]
		public AudioClip[] soundClips;
		[HideInInspector] public AudioSource source;

		public void Start()
		{
			particles = GetComponentInChildren<ParticleSystem>();
			source = GetComponentInChildren<AudioSource>();
		}


		public void Play()
		{
			if (particles != null)
			{
				particles.Play();
			}
			if (soundClips.Length != 0)
			{
				int rand = Random.Range(0, soundClips.Length - 1);
				source.PlayOneShot(soundClips[rand]);
			}
		}

		public AudioClip GetAudioClip()
		{
			int rand = Random.Range(0, soundClips.Length - 1);
			return soundClips[rand];
		}
	}

	[System.Serializable]
	public class OneShotAudioClip
	{
		public AudioClip clip;
		public float volume = 1;
	}
}
