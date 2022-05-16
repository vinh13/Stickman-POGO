using DevOne.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ScriptOrder(-10023)]
public class MoreGameController : Singleton<MoreGameController>
{
    public static event Action OnMoreGameItemLoaded;
    public const string ItemRemoteKey = "MoreGame";

    private MoreGamItemWrapper itemsWrapper;
    public override void InitInAwake()
    {
        itemsWrapper = new MoreGamItemWrapper();

        RemoteSettings.Updated += RemoteSettings_Updated;
    }

    private void RemoteSettings_Updated()
    {
        string json = RemoteSettings.GetString(ItemRemoteKey, "");
        var wrapper = JsonUtility.FromJson<MoreGamItemWrapper>(json);

        if(wrapper != null && wrapper.items.Count > 0)
        {
            itemsWrapper = wrapper;
            if (OnMoreGameItemLoaded != null)
            {
                OnMoreGameItemLoaded.Invoke();
            }
        }


    }

    public  List<MoreGameItem> GetItems()
    {
        return itemsWrapper.items;
    }
}
