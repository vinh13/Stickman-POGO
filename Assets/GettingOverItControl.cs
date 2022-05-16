using UnityEngine;
using System.Collections;
using CnControls;

public class GettingOverItControl : MonoBehaviour
{
    JointMotor2D jointMotor2d = new JointMotor2D();
    public Rigidbody2D rg2dStick, rg2d;
    public WheelJoint2D wheelJoint2D;
    public float speedRo;
    bool moveLeft = false;
    bool moveRight = false;
    bool isStop = false;
    public Transform Control, centerOfMass;
    public float rangeY = 0.5F;
    float rangeTemp = 0;

    void Start()
    {
        jointMotor2d.maxMotorTorque = 100000;
        rangeTemp = 0;
        rg2d.centerOfMass = centerOfMass.position;
    }

    void Update()
    {
//        #if UNITY_EDITOR
//        if (Input.GetKey(KeyCode.A))
//        {
//            LEFT();
//        }
//        else if (Input.GetKey(KeyCode.D))
//        {
//            RIGHT();
//        }
//        else
//        {
//            Stop();
//        }
//
//        if (Input.GetKey(KeyCode.UpArrow))
//        {
//            Stick_Up();
//        }
//        else if (Input.GetKey(KeyCode.DownArrow))
//        {
//            Stick_Down();
//        }
//        #endif

        if (CnInputManager.GetButton("Jump"))
        {
            LEFT();
        }
        else if (CnInputManager.GetButton("Jump1"))
        {
            RIGHT();
        }
        else
        {
            Stop();
        }

        float v = CnInputManager.GetAxis("Vertical");

        if (v > 0)
        {
            Stick_Up();
        }
        else if (v < 0)
        {
            Stick_Down();
        }

       
    }

    void Anchor()
    {
        wheelJoint2D.anchor = new Vector2(0, rangeTemp);
    }

    void Stick_Up()
    {
        rangeTemp -= 0.02F;


        rangeTemp = Mathf.Clamp(rangeTemp, -rangeY, rangeY);
        Vector3 temp = Control.localPosition;
        temp.y = rangeTemp;
        Control.localPosition = temp;

        Anchor();

    }

    void Stick_Down()
    {
        rangeTemp += 0.01F;
       

        rangeTemp = Mathf.Clamp(rangeTemp, -rangeY, rangeY);
        Vector3 temp = Control.localPosition;
        temp.y = rangeTemp;
        Control.localPosition = temp;

        Anchor();
    }


    void LEFT()
    {
        if (moveLeft)
            return;
        moveLeft = true;


        Rotator(1);


        moveRight = false;
        isStop = false;
    }

    void RIGHT()
    {
        if (moveRight)
            return;
        moveRight = true;


        Rotator(-1);


        moveLeft = false;
        isStop = false;

    }

    void Rotator(int direction)
    {
        rg2dStick.freezeRotation = false;
        wheelJoint2D.useMotor = true;
        jointMotor2d.motorSpeed = direction * speedRo;
        wheelJoint2D.motor = jointMotor2d;
    }

    void Stop()
    {
        if (isStop)
            return;
        isStop = true;
        rg2dStick.velocity = Vector2.zero;

        wheelJoint2D.useMotor = false;
        rg2dStick.freezeRotation = true;
        moveLeft = moveRight = false;
        rg2d.velocity = Vector2.zero;

    }
}
