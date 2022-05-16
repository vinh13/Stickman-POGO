using UnityEngine;
using System.Collections;

public class AxeCheck : MonoBehaviour
{
    public static bool isGround = false;

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "ground")
        {
            isGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "ground")
        {
            isGround = false;
        }
    }
}
