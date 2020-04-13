using System;
using UnityEngine;

public class TimerInLog : MonoBehaviour
{
	public int timeToCount = 3;
	private Timer timer;

	private void Awake() {
		timer = GetComponent<Timer> ();
	}

	public void StartSmootCoutnDown() {
		timer.Countdown ((float)timeToCount, false, PrintInLog);
	}

	public void StartCountDownAsync() {
		Timer.CountdownAsync (timeToCount, false, PrintInLog);
	}

	public void StartCountDownCoroutine() {
		timer.Countdown (timeToCount, false, PrintInLog);
	}

	private void PrintInLog(int time) {
		Debug.Log (time);
	}

	private void PrintInLog(float time) {
		Debug.Log (Math.Truncate(time*1000) / 1000);
	}

}
