using DevOne.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ScriptOrder(-10001)]
public class MusicManager : Singleton<MusicManager>
{
    public Dictionary<string, AudioClip> backgroundMusics = new Dictionary<string, AudioClip>();

    private AudioSource backgroundAudio;

    public  bool IsOn
    {
        get
        {
            return PlayerPrefs.GetInt("DevOne.MusicBackground", 1) == 1;
        }

        set
        {
            PlayerPrefs.SetInt("DevOne.MusicBackground", value ? 1 : 0);

            backgroundAudio.mute = !value;
        }
    }

     public override void InitInAwake()
    {
        backgroundAudio = GetComponent<AudioSource>();
        backgroundAudio.loop = true;
        backgroundAudio.playOnAwake = true;

        backgroundAudio.mute = !IsOn;

        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        string sceneName = arg0.name;


        if (backgroundMusics.ContainsKey(sceneName))
        {
            backgroundAudio.clip = backgroundMusics[sceneName];
        }
    }
}
