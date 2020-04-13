using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Timer :MonoBehaviour {

	private WaitForSeconds gameTimeWaiting = new WaitForSeconds (1);
	private WaitForSecondsRealtime realTimeWaiting = new WaitForSecondsRealtime (1);

	public void Countdown(
		float time,
		bool isRealSeconds = false,
		Action<float> callback = null
	) {
		StartCoroutine (SmootCountDown(time, isRealSeconds,callback));
	}

	public static async void CountdownAsync(
		int time, 
		bool isRealSeconds, 
		Action<int> callbackBySecond = null
	) {
		int remainingTime = time;
		callbackBySecond?.Invoke (remainingTime);
		while (remainingTime > 0) {
			await Task.Delay (1000);
			remainingTime--;
			callbackBySecond?.Invoke (remainingTime);
		}
	}

	public void Countdown(
		int time, 
		bool isRealSeconds, 
		Action<int> callbackBySecond = null
	) {
		if (isRealSeconds) {
			StartCoroutine (CountdownRealTime (time, callbackBySecond));
		} else {
			StartCoroutine (CountdownGameTime (time, callbackBySecond));
		}
	}

	private IEnumerator SmootCountDown(float time, bool isRealSeconds, Action<float> callback) {
		float remainingTime = time;
		callback?.Invoke (remainingTime);
		while (Math.Truncate (remainingTime * 100) > 0) {
			remainingTime -= isRealSeconds ? Time.unscaledDeltaTime : Time.deltaTime;
			callback?.Invoke (remainingTime);
			yield return null;
		}
		remainingTime = 0;
		callback?.Invoke (remainingTime);
	}


	private IEnumerator CountdownRealTime(int time, Action<int> callbackBySecond) {
		int remainingTime = time;
		callbackBySecond?.Invoke (remainingTime);
		while (remainingTime > 0) {
			yield return realTimeWaiting;
			remainingTime--;
			callbackBySecond?.Invoke (remainingTime);
		}
	}

	private IEnumerator CountdownGameTime(int time, Action<int> callbackBySecond) {
		int remainingTime = time;
		callbackBySecond?.Invoke (remainingTime);
		while (remainingTime > 0) {
			yield return gameTimeWaiting;
			remainingTime--;
			callbackBySecond?.Invoke (remainingTime);
		}
	}
}

