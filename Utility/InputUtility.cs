using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityUtils.Utilities
{
	public class InputUtility : MonoBehaviour
	{

		/// <summary>
		/// A Input.GetAxis replacement for the callback-based new Input System, where interpolating values based on buttons aren't much a thing.
		/// </summary>
		[System.Serializable]
		public class SmoothAxis
		{

			float m_targetValue;

			float currentValue;
			public float speed = 5f;

			float m_lastUpdateTime;
			public float rawValue
			{
				get
				{
					return m_targetValue;
				}
			}

			public float Read()
			{
				//Update it if it hasnt been updated on this frame
				if (m_lastUpdateTime != Time.time)
				{
					m_lastUpdateTime = Time.time;
					UpdateValue();
				}

				return currentValue;
			}

			void UpdateValue()
			{
				currentValue = Mathf.MoveTowards(currentValue, m_targetValue, speed * Time.deltaTime);
			}

			public void SetTargetValue(float f)
			{
				m_targetValue = f;
			}
		}
	}
}