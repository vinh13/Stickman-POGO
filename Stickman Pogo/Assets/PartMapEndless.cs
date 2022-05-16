using UnityEngine;
using System.Collections;

public class PartMapEndless : MonoBehaviour
{
    public Transform checkPoint;
    bool actived = false;

    void Awake()
    {
        actived = gameObject.activeSelf;
    }

    public void Off()
    {
        if (!actived)
            return;
        actived = false;
        gameObject.SetActive(false);
    }

    public void On()
    {
        if (actived)
            return;
        actived = true;
        gameObject.SetActive(true);
    }

    public void Check(float x)
    {
        if (Mathf.Abs(x - transform.position.x) <= 45F)
        {
            On();
        }
        else
        {
            Off();
        }
    }
}
