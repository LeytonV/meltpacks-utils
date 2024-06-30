using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityUtils.Utilities
{
	public static class PhysicsUtils
	{
		/// <summary>
		/// Useful for wheel physics. You don't want your wheels to have no horizontal grip, right?
		/// </summary>
		/// <param name="rb"></param>
		/// <returns></returns>
		public static void RestrictSidewaysVelocity(Rigidbody rb, float slip = 0)
		{
			Vector3 localVel = rb.transform.InverseTransformDirection(rb.velocity);
			localVel.x *= slip;
			rb.velocity = rb.transform.TransformDirection(localVel);
		}

		/// <summary>
		/// Useful for wheel physics. You don't want your wheels to have no horizontal grip, right?
		/// </summary>
		/// <param name="rb"></param>
		/// <returns></returns>
		public static void RestrictXZVelocity(Rigidbody rb, float slip = 0)
		{
			Vector3 localVel = rb.transform.InverseTransformDirection(rb.velocity);
			localVel.x *= slip;
			localVel.z *= slip;
			rb.velocity = rb.transform.TransformDirection(localVel);
		}

		/// <summary>
		/// Useful for wheel physics. You don't want your wheels to have no horizontal grip, right?
		/// </summary>
		/// <param name="rb"></param>
		/// <returns></returns>
		public static void RestrictUpwardsVelocity(Rigidbody rb, float friction = 0)
		{
			Vector3 localVel = rb.transform.InverseTransformDirection(rb.velocity);
			localVel.y *= friction;
			rb.velocity = rb.transform.TransformDirection(localVel);
		}

		public static Vector3 GetLocalVelocity(this Rigidbody rb)
		{
			Vector3 localVel = rb.transform.InverseTransformDirection(rb.velocity);
			return localVel;
		}
	}
}