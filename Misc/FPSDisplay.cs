using UnityEngine;
using MUnityUtils.Utilities;
namespace MUnityUtils
{
	public class FPSDisplay : MonoBehaviour
	{
		[SerializeField] private float _hudRefreshRate = 1f;

		private float _timer;

		public UnityStringEvent onUpdateText;

		private void Update()
		{
			if (Time.unscaledTime > _timer)
			{
				int fps = (int)(1f / Time.unscaledDeltaTime);
				_timer = Time.unscaledTime + _hudRefreshRate;
				onUpdateText.Invoke("FPS: " + fps);
			}
		}
	}

}
