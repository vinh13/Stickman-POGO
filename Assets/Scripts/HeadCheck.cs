using UnityEngine;
using System.Collections;

public class HeadCheck : MonoBehaviour
{
    public float breakForce;
    Rigidbody2D rg2d;
    PartBody partbody;
    int countDame = 0;
    public int health = 5;
    public PartBody[] partbodyContact;
    public StickmanConfig stickmanConfig;

    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        partbody = GetComponent<PartBody>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (partbody.hit || partbody.deathed)
            return;
        string tagname = coll.gameObject.tag;

        int countContact = coll.contacts.Length;

        if (tagname == "ground" || tagname == "trapp")
        {
            float force = rg2d.velocity.magnitude;
            if (force >= breakForce)
            {
                partbody.OnHit();

                Vector2 posContact = Vector2.zero;

                if (countContact == 0)
                {
                }
                else
                {
                    posContact = coll.contacts[0].point;
                }

                EffectManager.Instance.PlayEffectHitStickman(posContact);


                countDame += 1;
                if (countDame >= health)
                {

                    SOUND_SYSTEM.Instance.OnPlayerHit();

                    OnDeath();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "FLAME")
        {
            SOUND_SYSTEM.Instance.OnPlayerHit();
            stickmanConfig.OnHitFire();
        }
    }

    public void OnDeath()
    {
        partbody.deathed = true;
        for (int i = 0; i < partbodyContact.Length; i++)
        {
            partbodyContact[i].OnDeath();
        }
        stickmanConfig.HeadCollision();
    }

}
