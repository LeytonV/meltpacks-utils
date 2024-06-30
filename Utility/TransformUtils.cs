using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityUtils.Utilities
{
	public static class TransformUtils
	{

		/// <summary>
		/// A quaternion-based implementation of unity's RotateAround method.
		/// </summary>
		/// <param name="pivotPoint">The point to rotate around.</param>
		/// <param name="rot">The quaternion to rotate the transform by.</param>
		public static void RotateAround(this Transform transform, Vector3 pivotPoint, Quaternion rot)
		{
			transform.position = rot * (transform.position - pivotPoint) + pivotPoint;
			transform.rotation = rot * transform.rotation;
		}

		/// <summary>
		/// A quaternion-based implementation of unity's RotateAround method, but in local space.
		/// </summary>
		/// <param name="pivotPoint">The point to rotate around, in local space.</param>
		/// <param name="rot">The quaternion to rotate the transform by.</param>
		public static void RotateAroundLocal(this Transform transform, Vector3 pivotPoint, Quaternion rot)
		{
			transform.localPosition = rot * (transform.localPosition - pivotPoint) + pivotPoint;
			transform.localRotation = rot * transform.localRotation;
		}
	}
}