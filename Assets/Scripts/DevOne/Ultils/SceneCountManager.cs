using DevOne.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ScriptOrder(-200)]
public class SceneCountManager : Singleton<SceneCountManager>
{
    private Dictionary<string, int> sceneCountDic;

    public override void InitInAwake()
    {
        sceneCountDic = new Dictionary<string, int>();
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;

    }

    private void SceneManager_sceneLoaded(Scene s, LoadSceneMode arg1)
    {
        Debug.Log("OnLevelWasLoaded: " + s.name);

        if (!sceneCountDic.ContainsKey(s.name))
        {
            sceneCountDic.Add(s.name, 1);
        }
        else
        {
            sceneCountDic[s.name] = sceneCountDic[s.name] + 1;
        }
    }


    public bool IsFirstTimeLoadScene(string sceneName)
    {
        if (!sceneCountDic.ContainsKey(sceneName))
        {
            return true;
        }

        if(sceneCountDic[sceneName] == 1)
        {
            return true;
        }

        return false;

    }

}
