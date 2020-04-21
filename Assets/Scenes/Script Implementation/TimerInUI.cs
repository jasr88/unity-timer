using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerInUI :MonoBehaviour {
	public int timeToCount = 3;

	public Text timer1;
	public Text timer2;
	public Text timer3;

	private Timer timer;

	private void Awake() {
		timer = GetComponent<Timer> ();
	}

	public void StartSmootCoutnDown() {
		timer.Countdown ((float)timeToCount, false, PrintInTimer1);
	}

	public void StartCountDownAsync() {
		Timer.CountdownAsync (timeToCount, PrintInTimer2); // This method doesn't allow time scaled counters
	}

	public void StartCountDownCoroutine() {
		timer.Countdown (timeToCount, false, PrintInTimer3);
	}



	private void PrintInTimer1(float time) {
		timer1.text = (Math.Truncate (time * 1000) / 1000).ToString ();
	}

	private void PrintInTimer2(int time) {
		timer2.text = time.ToString ();
	}

	private void PrintInTimer3(int time) {
		timer3.text = time.ToString ();
	}

}
