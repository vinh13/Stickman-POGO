using UnityEngine;
using System.Collections;

public class GOIStick : MonoBehaviour
{
    public Rigidbody2D rg2d;
    public Transform centerOfMass;

    void Start()
    {
        rg2d.centerOfMass = centerOfMass.position;
    }
}
