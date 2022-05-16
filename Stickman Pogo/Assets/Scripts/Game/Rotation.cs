using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
	public float speedRotation = 1F;

	void Update ()
	{
		transform.Rotate (Vector3.forward * speedRotation * Time.unscaledDeltaTime);
	}
}
