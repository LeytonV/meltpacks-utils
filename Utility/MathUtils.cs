using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MUnityUtils.Utilities
{
	public static class MathUtils
	{
		public static float boolToFloat(this bool b)
		{
			if (b)
				return 1f;
			else
				return 0f;
		}

		public static float DistanceBetween(float v1, float v2)
		{
			return Mathf.Max(v1, v2) - Mathf.Min(v1, v2);
		}

		/// <summary>
		/// Returns true if (num) is in (range) of (dest)
		/// </summary>
		/// <param name="num">The position we are at</param>
		/// <param name="dest">The position we want to move to</param>
		/// <param name="range">The range</param>
		/// <returns></returns>
		public static bool InRange(float num, float dest, float range)
		{
			return num > dest - range && num < dest + range;
		}

		public static float GetPercent(float percentWanted, float number)
		{
			float divideBy = 100 / percentWanted;
			return number / divideBy;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="val"></param>
		/// <returns>1 if value is more than zero, -1 if value is less, and 0 if equal</returns>
		public static float SignedValue(float val)
		{
			if (val > 0) return 1;
			else if (val < 0) return -1;
			else return 0;
		}


		/// <summary>
		/// Unity Port of .NET's MathF.MaxMagnitude.
		/// </summary>
		/// <returns>The biggest value in size, regardless of sign</returns>
		public static float MaxMagnitude(float val1, float val2)
		{
			float abs1 = Mathf.Abs(val1);
			float abs2 = Mathf.Abs(val2);

			//1 more than 2, or 1 is so big its not even a number, return 1
			if (abs1 > abs2 || float.IsNaN(abs1))
			{
				return val1;
			}

			//If both equal, return the regular biggest one
			if (abs1 == abs2)
			{
				return Mathf.Max(val1, val2);
			}

			//Otherwise idfk dude we already compared greater and equal cases just fucking return something
			//I love using vulgar language in code comments it reminds me of valve employees losing their mind writing TF2 spaghetti
			return val2;
		}

		/// <summary>
		/// Unity Port of .NET's MathF.MinMagnitude.
		/// </summary>
		/// <returns>The smallest value in size, regardless of sign</returns>
		public static float MinMagnitude(float val1, float val2)
		{
			float abs1 = Mathf.Abs(val1);
			float abs2 = Mathf.Abs(val2);

			//1 more than 2, or 1 is so big its not even a number, return 1
			if (abs1 < abs2 || float.IsNaN(abs1))
			{
				return val1;
			}

			//If both equal, return the regular biggest one
			if (abs1 == abs2)
			{
				return Mathf.Min(val1, val2);
			}

			//Otherwise idfk dude we already compared greater and equal cases just fucking return something
			//I love using vulgar language in code comments it reminds me of valve employees losing their mind writing TF2 spaghetti
			return val2;
		}

	}
}