using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace MUnityUtils.Utilities
{
	/// <summary>
	/// A .NET-based implementation of Unity's Random class. Useful for deterministic results
	/// </summary>
	public static class RandomUtils
	{
		public static Vector3 onUnitCircle(this Random random)
		{
			// credit to Pulni for offering this solution over my last one!
			var angle = random.Range(0, 360f) * Mathf.Deg2Rad;
			var x = Mathf.Cos(angle);
			var y = Mathf.Sin(angle);

			Vector3 vec = new Vector3(x, y, 0);
			return vec;
		}

		public static Vector2 insideUnitCircle(this Random random)
		{
			return random.onUnitCircle() * random.Range();
		}

		public static float Range(this Random random, float min = 0f, float max = 1f)
		{
			return Mathf.Lerp(min, max, (float)random.NextDouble());
		}

		/// <summary>
		/// Generates a random int from min (inclusive) and max (exclusive)
		/// </summary>
		/// <param name="random"></param>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static int Range(this Random random, int min, int max)
		{
			return random.Next(min, max);
		}

		public static Vector3 insideUnitSphere(this Random random)
		{
			return new Vector3(random.Range(-1f, 1f), random.Range(-1f, 1f), random.Range(-1f, 1f));
		}

		public static Vector3 onUnitSphere(this Random random)
		{
			return random.insideUnitSphere().normalized;
		}
	}
}