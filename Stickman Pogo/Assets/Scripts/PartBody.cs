using UnityEngine;
using System.Collections;

public class PartBody : MonoBehaviour
{
    public SpriteRenderer[] spr;
    public StickmanConfig stickmanConfig;
    public bool hidenbody = false;
    [SerializeField] HingeJoint2D hingeJoint2D;
    [SerializeField] Rigidbody2D rg2d;
    public float[] angleLimits = new float[2];
    Color32 colorHit;
    Color temp;
    public SpriteRenderer sprHit, spSke;
    public bool _checkTrapp = true;

    void OnValidate()
    {
        int i = hidenbody ? 1 : 0;
        temp = stickmanConfig.colors[i];
        SetColor(temp);
    }

    void Start()
    {


        deathed = false;

        transform.SetParent(null);

        colorHit = Color.red;

        int i = hidenbody ? 1 : 0;
        temp = stickmanConfig.colors[i];

        SetColor(temp);
        if (hingeJoint2D)
        {
            hingeJoint2D.useLimits = true;
            JointAngleLimits2D limit = new JointAngleLimits2D();

            limit.min = angleLimits[0];
            limit.max = angleLimits[1];

            hingeJoint2D.limits = limit;
        }

        sprHit.enabled = false;
    }

    public void SetColor(Color color)
    {
        for (int i = 0; i < spr.Length; i++)
        {
            spr[i].color = color;
        }
    }

    [HideInInspector]public bool hit = false;
    [HideInInspector]public bool deathed = false;

    public void OnDeath()
    {
        hingeJoint2D.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (deathed)
            return;
        string nameTag = coll.gameObject.tag;

        if (nameTag == "TnT")
        {
            EffectManager.Instance.PlayEffectHitStickman(transform.position);
            deathed = true;
            if (hingeJoint2D)
            {
                OnDeath();
                OnHit();
            }
        }
        if (!_checkTrapp)
            return;
        if (hit)
            return;
        if (nameTag == "trapp")
        {
            OnHit();
            EffectManager.Instance.PlayEffectHitStickman(coll.contacts[0].point);
        }
    }

    float alpha = 0;

    public void OnHit()
    {
        SOUND_SYSTEM.Instance.OnPlayerHit();

        if (spSke)
        {
            spSke.enabled = true;
        }

        hit = true;

        timer = 0;
        colorHit.a = 255;

        alpha = 255F / 4F;

        sprHit.enabled = true;
        sprHit.color = colorHit;

        StartCoroutine(delayOnHit());
    }

    IEnumerator delayOnHit()
    {
        yield return new WaitForSecondsRealtime(1f);
        hit = false;
        sprHit.enabled = false;
        if (spSke)
        {
            spSke.enabled = false;
        }
    }

    float timer = 0;

    void Update()
    {
        if (hit)
        {
            timer += Time.deltaTime;
            if (timer > 0.25f)
            {
                timer = 0;
                colorHit.a -= (byte)alpha;
                sprHit.color = colorHit;
            }
        }
    }

    [SerializeField]Collider2D collMain;

    public void EnableCollision()
    {
        if (collMain)
            collMain.enabled = true;
    }
}
