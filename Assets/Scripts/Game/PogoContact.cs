using UnityEngine;
using System.Collections;
using CnControls;

public class PogoContact : MonoBehaviour
{

	public float rotationSpeed = 1F;
	public float speedMin = 2F;
	[SerializeField]Rigidbody2D rg2d;
	[SerializeField]Transform centerOfMass;
	[SerializeField]PogoControl pogoControl;
	[SerializeField]WheelJoint2D wheelJoint2D;
	bool jumped = false;
	public float powerJump = 100, powerDeath;
	public Transform Direction;
	public StickmanConfig stickmanConfig;
	public static bool deathed = false;
	[Header ("DIRECTION CONTROL")]
	public int directionTap = -1;

	[Header ("Rotation Start")]
	public float rotationStart = -5;

	float rotationSpeedTemp = 0;
	public bool intro = false;

	public static int countJump = 0;


	void Start ()
	{


		countJump = 0;

		rg2d.centerOfMass = centerOfMass.position;
		jumped = false;
		deathed = false;

		pogoControl.Rotation (rotationStart);
		rg2d.rotation = rotationStart;


		transform.SetParent (null);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (deathed)
			return;
		string tag = coll.gameObject.tag;

		int countContact = coll.contacts.Length;

		if (tag == "ground") {
			if (!jumped) {
				jumped = true;
				CALLJUMP ();

				Vector2 posContact;
				if (countContact == 0) {
					Debug.Log ("PogoContact no contact point !!!");
				} else {
					posContact = coll.contacts [0].point;
					EffectManager.Instance.PlayEffectHitGround (posContact);
					EffectManager.Instance.PlayEffectSaveGround (posContact);
				}

			}
		}
		if (tag == "TnT") {
			deathed = true;

			CameraControl.Instance.RemoveAllTargets ();

			CameraControl.Instance.ZoomOut (0.25f);

			pogoControl.FreezeRotation (false);

			Vector2 temp = rg2d.velocity;
			temp.Normalize ();


			Vector2 posContact = Vector2.zero;
			if (countContact == 0) {
				Debug.Log ("PogoContact no contact point !!!");
			} else {
				posContact = coll.contacts [0].point;
			}

			rg2d.AddForceAtPosition (temp * -powerDeath, posContact);
			stickmanConfig.BreakContactAll ();

			Destroy (this.gameObject);

		}
	}

	bool zoomIn = false;

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (deathed)
			return;

		if (coll.tag == "checkpoint") {
			HUDManager.Instance.OnWin ();
		}
		if (zoomIn)
			return;
		if (coll.tag == "ground") {
			if (!intro) {
				CameraControl.Instance.ZoomIn (0.25f);
				zoomIn = true;
				Invoke ("ResetZoomIn", 0.5F);
			}
		}
	}

	void ResetZoomIn ()
	{
		zoomIn = false;
	}

	void CALLJUMP ()
	{
		SOUND_SYSTEM.Instance.Jump ();
		rg2d.isKinematic = true;
		StartCoroutine (delayJump ());

	}

	void JUMP ()
	{
		countJump += 1;
		rg2d.isKinematic = false;
		Vector2 temp = Direction.position - transform.position;
		temp.Normalize ();
		pogoControl.JUMP (temp * powerJump);
		if (!intro) {
			CameraControl.Instance.ZoomOut (0.25f);
		}
	}

	IEnumerator delayJump ()
	{
		yield return new WaitForSecondsRealtime (0.08f);
		JUMP ();
		yield return new WaitForSecondsRealtime (0.25f);
		jumped = false;
	}

	void FixedUpdate ()
	{
		if (deathed)
			return;
		//float h = CnInputManager.GetAxis ("Horizontal");
		float h = TdzInputManager.horizontal;
		float step = h * rotationSpeedTemp;
		if (Mathf.Abs (h) == 0) {
			rotationSpeedTemp = speedMin;
			return;

		}

		if (rotationSpeedTemp < rotationSpeed) {
			rotationSpeedTemp += 0.1F;
		}
		float temp = rg2d.rotation;
		temp += directionTap * step;

		if (Mathf.Abs (temp) <= 80F) {
			rg2d.rotation = temp;
			pogoControl.Rotation (temp);
		}
	}
}
