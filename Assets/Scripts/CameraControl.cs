using UnityEngine;
using System.Collections;
using Com.LuisPedroFonseca.ProCamera2D;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public bool isTEST = false;
    Transform checkPoint, pogocontact;
    public bool endlessMode = false;

    void Awake()
    {
        Instance = this;
    }

    public float sizeCamMax;
    public float sizeCamMin;
    public float sizeCam;
    public ProCamera2D procamera2D;

    void Start()
    {
        if (!isTEST)
        {
            if (!endlessMode)
            {
                procamera2D.RemoveAllCameraTargets();

                procamera2D.UpdateScreenSize(sizeCam, 0, EaseType.Linear);
                checkPoint = GameObject.FindGameObjectWithTag("checkpoint").transform;
                pogocontact = GameObject.FindGameObjectWithTag("contact").transform;

                procamera2D.AddCameraTarget(checkPoint, 1, 1, 0, Vector2.zero);


                StartCoroutine(delayStart());
            }
            else
            {
                Restore();
            }
        }
        else
        {
            Restore();
        }

    }

    public void Restore()
    {

        procamera2D.RemoveAllCameraTargets();

//        procamera2D.FollowHorizontal = false;
//        procamera2D.FollowVertical = false;

        procamera2D.UpdateScreenSize(sizeCam, 0, EaseType.Linear);

        procamera2D.VerticalFollowSmoothness = 0.15F;
        procamera2D.HorizontalFollowSmoothness = 0.15F;

        pogocontact = GameObject.FindGameObjectWithTag("contact").transform;
        procamera2D.AddCameraTarget(pogocontact, 1, 1, 0.0F, Vector2.zero);


        StartCoroutine(delayRestore());
    }

    IEnumerator delayRestore()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        procamera2D.VerticalFollowSmoothness = 0.0F;
        procamera2D.HorizontalFollowSmoothness = 0.0F;

    }

    IEnumerator delayStart()
    {
        yield return new WaitForSecondsRealtime(1F);
        procamera2D.RemoveAllCameraTargets();

        procamera2D.HorizontalFollowSmoothness = 0.25F;
        procamera2D.AddCameraTarget(pogocontact, 1, 1, 0.5F, Vector2.zero);

        yield return new WaitForSecondsRealtime(0.5F);

        procamera2D.HorizontalFollowSmoothness = 0;
    }


    public void ZoomOut(float duration)
    {
        procamera2D.UpdateScreenSize(sizeCamMax, duration, EaseType.EaseOut);
    }

    public void ZoomIn(float duration)
    {
        procamera2D.UpdateScreenSize(sizeCamMin, duration, EaseType.EaseIn);
    }

    public void RemoveAllTargets()
    {
        procamera2D.RemoveAllCameraTargets();
    }
}
