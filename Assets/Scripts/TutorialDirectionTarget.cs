using UnityEngine;
using System.Collections;

public class TutorialDirectionTarget : MonoBehaviour
{
    public Transform start, target;
    public Transform arrowDirection;

    void Start()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("checkpoint").transform;
        
    }

    void LateUpdate()
    {
        Vector3 temp = target.position - start.position;
        float rot_z = Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg;
        arrowDirection.rotation = Quaternion.Slerp(arrowDirection.rotation, Quaternion.AngleAxis(rot_z, Vector3.forward), .025F);

    }
}
