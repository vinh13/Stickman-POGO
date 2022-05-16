using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class HandWeapon : MonoBehaviour
{
	bool attacked = false;
	int direction = 1;
	[SerializeField]float force;
	public Rigidbody2D rg2d;
	[SerializeField]Transform start, target;

	void Awake ()
	{
		//handWeaponConfig = Resources.Load<HandWeaponConfig> (pathFileConfig);
		attacked = false;
	}

	void Update ()
	{
		if (!attacked) {
			if (CnInputManager.GetButtonDown ("Jump")) {
				Attack ();
			}
		}
	}

	void Attack ()
	{
		attacked = true;
		Vector2
		direction = target.position - start.position;
		rg2d.AddForceAtPosition (direction.normalized * force, start.position);
		StartCoroutine (delayAttack ());
	}

	IEnumerator delayAttack ()
	{
		yield return new WaitForSeconds (1f);
		attacked = false;
	}

}
