using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public CreateObjectPooling effectHitGround;

    public void PlayEffectHitGround(Vector3 pos)
    {
        effectHitGround._ChooseEffect(pos);
    }

    public CreateObjectPooling effectHitStickman;

    public void PlayEffectHitStickman(Vector3 pos)
    {
        effectHitStickman._ChooseEffect(pos);
    }


    public CreateObjectPooling effectSaveGround;

    public void PlayEffectSaveGround(Vector3 pos)
    {
        effectSaveGround._ChooseEffect(pos);
    }
}
