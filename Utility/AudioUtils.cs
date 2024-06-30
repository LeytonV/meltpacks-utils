using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityUtils.Utilities
{
	public static class AudioUtils
	{
		public static void PlayOneShot(this AudioSource source, SoundGroup group)
		{
			if (group != null)
			{
				AudioClip randomClip = group.GetClip();
				if (randomClip != null)
				{
					source.PlayOneShot(randomClip, group.volume);
				}
				else
				{
					//-1 means no clips
					if (group.clips.Length == 0)
					{
						Debug.LogError("Error playing SoundClip on " + source.name + ": No clips!");
					}
					else
					{
						Debug.LogError("Error playing SoundClip on " + source.name + ":One of your clips are null!");
					}
				}
			}
		}

		public static void PlayOneShot(this AudioSource source, SoundGroup group, float volumeScale = 1)
		{
			if (group != null)
			{
				AudioClip randomClip = group.GetClip();
				if (randomClip != null)
				{
					source.PlayOneShot(randomClip, group.volume * volumeScale);
				}
				else
				{
					//-1 means no clips
					if (group.clips.Length == 0)
					{
						Debug.LogError("Error playing SoundClip on " + source.name + ": No clips!");
					}
					else
					{
						Debug.LogError("Error playing SoundClip on " + source.name + ":One of your clips are null!");
					}
				}
			}
		}
	}

	[System.Serializable]
	public class SoundGroup
	{
		public AudioClip[] clips;
		public float volume = 1;

		public AudioClip GetClip()
		{
			if (clips.Length == 0)
			{
				return null;
			}
			else
			{
				return clips[Random.Range(0, clips.Length)];
			}
		}
	}
}
