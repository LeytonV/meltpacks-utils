using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityUtils.Utilities
{
	public static class VectorUtils
	{
		/// <summary>
		/// Gets the direction from one vector to another (normalized).
		/// </summary>
		/// <param name="from">The position we are at</param>
		/// <param name="to">The position we want to point at</param>
		/// <returns></returns>
		public static Vector3 GetDirection(Vector3 from, Vector3 to, bool normalized = true)
		{
			if (normalized)
				return (to - from).normalized;
			else
				return to - from;
		}

		public static Vector3 AverageDirection(Vector3[] dirs)
		{
			Vector3 result = Vector3.zero;
			foreach (Vector3 dir in dirs)
			{
				result += dir;
			}
			result /= dirs.Length;
			return result;
		}
		public static Vector3 AveragePoint(RaycastHit[] dirs)
		{
			Vector3 result = Vector3.zero;
			foreach (RaycastHit dir in dirs)
			{
				result += dir.point;
			}
			result /= dirs.Length;
			return result;
		}

		/// <summary>
		/// Gets the direction from one vector to another (normalized).
		/// </summary>
		/// <param name="from">The position we are at</param>
		/// <param name="to">The position we want to point at</param>
		/// <returns></returns>
		public static Vector3 MoveTo(Vector3 from, Vector3 to, float amount = 1)
		{
			return from + GetDirection(from, to) * amount;
		}

		#region Swizzling
		/// <summary>
		/// The X and Z of a vector
		/// </summary>
		/// <returns></returns>
		public static Vector3 xz(this Vector3 vector)
		{
			return new Vector3(vector.x, 0, vector.z);
		}

		/// <summary>
		/// The X and Y of a vector
		/// </summary>
		/// <returns></returns>
		public static Vector3 xy(this Vector3 vector)
		{
			return new Vector3(vector.x, vector.y, 0);
		}

		/// <summary>
		/// The Y and Z of a vector
		/// </summary>
		/// <returns></returns>
		public static Vector3 yz(this Vector3 vector)
		{
			return new Vector3(0, vector.y, vector.z);
		}
		#endregion

		public static float GetVelocityInDirection(Vector3 vel, Vector3 dir)
		{
			return vel.magnitude * Mathf.Clamp01(Vector3.Dot(vel.normalized, dir));
		}

		public static float Scale(Vector3 vel, Vector3 dir)
		{
			return vel.magnitude * Mathf.Clamp01(Vector3.Dot(vel.normalized, dir));
		}

		public static Vector3Int RoundToInt(this Vector3 vec)
		{
			return new Vector3Int(Mathf.RoundToInt(vec.x), Mathf.RoundToInt(vec.y), Mathf.RoundToInt(vec.z));
		}

		public static Vector3 Multiply(Vector3 one, Vector3 two)
		{
			return new Vector3(one.x * two.x, one.y * two.y, one.z * two.z);
		}

		public static Vector3 Absolute(Vector3 vec)
		{
			return new Vector3(Mathf.Abs(vec.x), Mathf.Abs(vec.y), Mathf.Abs(vec.z));
		}

		public static Vector3 RandomVector(float variance = 1)
		{
			return new Vector3(Random.Range(-variance, variance), Random.Range(-variance, variance), Random.Range(-variance, variance)).normalized;
		}

		public static Vector3 TwoToThree(Vector2 vec)
		{
			return new Vector3(vec.x, 0, vec.y);
		}

		public static Vector3 Center(Vector3 one, Vector3 two)
		{
			Vector3 vec = GetDirection(one, two, false);
			return vec / 2f;
		}

		public static Vector3 ApplyFriction(Vector3 vec, float friction)
		{
			vec.x /= 1 + friction * Time.deltaTime;
			vec.z /= 1 + friction * Time.deltaTime;
			return vec;
		}

		public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
		{
			return Quaternion.Euler(angles) * (point - pivot) + pivot;
		}

		public static Vector3 HalfVector(Vector3 v1, Vector3 v2)
		{
			return Vector3.Lerp(v1, v2, .5f);
		}
	}
}