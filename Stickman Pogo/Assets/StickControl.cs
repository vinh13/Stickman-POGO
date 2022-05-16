using UnityEngine;
using System.Collections;
using CnControls;

public class StickControl : MonoBehaviour
{
    public Rigidbody2D rg2d;
    public Transform centerOfMass;
    public float speedRo;

    void Start()
    {
        rg2d.centerOfMass = centerOfMass.position;
    }

    void Update()
    {
        float h = CnInputManager.GetAxis("Horizontal");
        float v = CnInputManager.GetAxis("Vertical");
        float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
        rg2d.MoveRotation(rg2d.rotation + angle * speedRo * Time.deltaTime);
    }
}
