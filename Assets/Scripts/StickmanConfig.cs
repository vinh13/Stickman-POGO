using UnityEngine;
using System.Collections;
using TungDz;

public class StickmanConfig : MonoBehaviour
{
    public Color[] colors;
    public FixedJoint2D fixedJoint2D_handA, fixedJoint2D_handB, fixedJoint2D_LegA, fixedJoint2D_LegB;
    public bool deathed = false;
    public PartBody[] partBodies;
    public FlameScript[] flameScript = new FlameScript[2];

    [SerializeField]GameObject[] chils;

    public void RemoveTarget()
    {
        for (int i = 0; i < partBodies.Length; i++)
        {
            Destroy(partBodies[i].gameObject);
        }
        for (int i = 0; i < chils.Length; i++)
        {
            Destroy(chils[i]);
        }
    }

    void Start()
    {
        deathed = false;
    }

    public void BreakContactAll()
    {
        if (deathed)
            return;
        deathed = true;
        fixedJoint2D_handA.enabled = false;
        fixedJoint2D_handB.enabled = false;
        fixedJoint2D_LegA.enabled = false;
        fixedJoint2D_LegB.enabled = false;


        PogoContact.deathed = true;

        EnableBodies();

        Invoke("OnLose", 3F);

    }

    void OnLose()
    {
        HUDManager.Instance.OnLose();
    }

    public void BreakBodies()
    {
        for (int i = 0; i < partBodies.Length; i++)
        {
            partBodies[i].OnDeath();
        }
    }

    public void EnableBodies()
    {
        for (int i = 0; i < partBodies.Length; i++)
        {
            partBodies[i].EnableCollision();
        }
    }

    public void HeadCollision()
    {
        fixedJoint2D_handA.enabled = false;
        fixedJoint2D_handB.enabled = false;

        for (int i = 6; i < partBodies.Length; i++)
        {
            partBodies[i].EnableCollision();
        }


        this.PostEvent(EventID.OnSlowMotion);
        PogoContact.deathed = true;



        Invoke("OnLose", 3F);
    }


    bool hitFire = false;

    public void OnHitFire()
    {
        if (hitFire)
            return;
        hitFire = true;
        flameScript[0].gameObject.SetActive(true);
        flameScript[1].gameObject.SetActive(true);



        StartCoroutine(delayOnHitFire());
    }

    IEnumerator delayOnHitFire()
    {
        yield return new WaitForSecondsRealtime(1f);
        deathed = true;
        fixedJoint2D_handA.enabled = false;
        fixedJoint2D_handB.enabled = false;
        fixedJoint2D_LegA.enabled = false;
        fixedJoint2D_LegB.enabled = false;
        PogoContact.deathed = true;



        EnableBodies();
        Invoke("OnLose", 2F);
    }
}
