using UnityEngine;
using System.Collections;
using TungDz;

public class SlowMotionManager : MonoBehaviour
{
	public float timeScaleInSlow = 0.2F;
	public float durationSlow = 2F;
	bool slowed = false;

	void Start ()
	{
		this.RegisterListener (EventID.OnSlowMotion, param => OnSlowMotion ());
	}

	void OnSlowMotion ()
	{
		if (slowed)
			return;
		slowed = true;
		StartCoroutine (delayOnSlowMotion ());
	}

	void Update ()
	{
		if (Logic.IsPause)
			return;
		if (slowed) {
			Time.timeScale = timeScaleInSlow;
		} else {
			Time.timeScale = 1F;
		}
		Time.fixedDeltaTime = 0.02F * Time.timeScale;
	}

	IEnumerator delayOnSlowMotion ()
	{
		yield return new WaitForSecondsRealtime (durationSlow);
		slowed = false;
	}
}
