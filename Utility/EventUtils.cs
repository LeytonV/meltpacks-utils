using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MUnityUtils.Utilities
{
	[System.Serializable]
	public class UnityStringEvent : UnityEvent<string>
	{

	}

	[System.Serializable]
	public class UnityFloatEvent : UnityEvent<float>
	{

	}

	[System.Serializable]
	public class UnityIntEvent : UnityEvent<int>
	{

	}

	[System.Serializable]
	public class UnityVector3Event : UnityEvent<Vector3>
	{

	}

	[System.Serializable]
	public class UnityVector2Event : UnityEvent<Vector2>
	{

	}
}
