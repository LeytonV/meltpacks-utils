using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityUtils.Utilities
{
	public static class BoundsUtils
	{
		/// <summary>
		/// Converts a Bounds into a BoundsInt
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public static BoundsInt RoundToInt(this Bounds b)
		{
			return new BoundsInt(Vector3Int.RoundToInt(b.center), Vector3Int.RoundToInt(b.size));
		}
	}
}