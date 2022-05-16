using UnityEngine;
using System.Collections;

public class AutoDisable : MonoBehaviour
{
	[SerializeField]ParticleSystem pars;
	bool isPlay = false;
	float timer = 0;
	public float timerMax = 0;
	void OnEnable ()
	{
		if (pars == null) {
			pars = this.GetComponent<ParticleSystem> ();
			timerMax = pars.duration;
		}
		if (pars) {
			pars.Play ();
			isPlay = true;
		}
	}

	void OnDisable ()
	{
		pars.Clear ();
		timer = timerMax;
	}

	void Update ()
	{
		if (!isPlay)
			return;
		timer -= Time.deltaTime;
		if (timer < 0) {
			this.gameObject.SetActive (false);
			isPlay = false;
		}
	}
}
