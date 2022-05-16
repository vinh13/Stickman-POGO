using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWeaponConfig : ScriptableObject
{
	public float motorSpeed;
	public float maxMotorTorque;
	public JointMotor2D  jointMotor2D (int direction)
	{
		JointMotor2D _jointMotor2D = new JointMotor2D ();

		_jointMotor2D.motorSpeed = motorSpeed * direction;
		_jointMotor2D.maxMotorTorque = maxMotorTorque;

		return _jointMotor2D;
	}
}
