using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoreGamItemWrapper
{
    public List<MoreGameItem> items;

    public MoreGamItemWrapper()
    {
        items = new List<MoreGameItem>();
    }
}
