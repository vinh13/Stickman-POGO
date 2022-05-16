using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour
{
    public _2dxFX_Flame flame;

    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }
}
