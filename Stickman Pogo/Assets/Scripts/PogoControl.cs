using UnityEngine;
using System.Collections;
using CnControls;

public class PogoControl : MonoBehaviour
{
	[SerializeField]Rigidbody2D rg2d;

    void Start(){
        transform.SetParent(null);
    }

	public void JUMP (Vector2 power)
	{
		rg2d.AddForce (power);
	}

	public void Rotation (float value)
	{
		rg2d.rotation = value;
	}

	public void FreezeRotation (bool status)
	{
		rg2d.freezeRotation = status;
	}
}
