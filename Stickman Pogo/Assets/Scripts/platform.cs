using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour
{
    [SerializeField]SpriteRenderer spr;
    public Color color;

    void Start()
    {
        spr.color = color;
    }
}
