using UnityEngine;
using System.Collections;

public class HandScript : MonoBehaviour
{
    public HingeJoint2D hingleJoint2D;
    public float min;
    public float max;

    void Start()
    {
        JointAngleLimits2D jointAngle2D = new JointAngleLimits2D();
        float temp = hingleJoint2D.jointAngle;
        jointAngle2D.min = temp - min;
        jointAngle2D.max = temp + max;

        hingleJoint2D.limits = jointAngle2D;

    }
}
