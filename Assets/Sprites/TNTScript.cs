using UnityEngine;
using System.Collections;
using TungDz;

public class TNTScript : MonoBehaviour
{
    public EffectTNT effect;
    public float breakForce;

    void Start()
    {
        effect.transform.SetParent(null);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            playEffect();
        }
    }

    private void playEffect()
    {
        SOUND_SYSTEM.Instance.Explosion();
        this.PostEvent(EventID.OnSlowMotion);
        effect.transform.position = this.transform.position;
        effect.Play();
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.relativeVelocity.magnitude > breakForce)
        {
            playEffect();
        }
    }
}
