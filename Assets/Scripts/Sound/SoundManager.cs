using DevOne.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ScriptOrder(-10002)]
public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private bool PlayFromReSource = true;

    [SerializeField]
    private string ResourcesFolderName = "Sounds";

    public bool IsOn
    {
        get
        {
            return PlayerPrefs.GetInt("DevOne.SoundOnFx", 1) == 1;
        }

        set
        {
            PlayerPrefs.SetInt("DevOne.SoundOnFx", value ? 1 : 0);

            mainAudioSource.mute = !value;
        }
    }


    private AudioSource mainAudioSource;

    public override void InitInAwake()
    {
        mainAudioSource = GetComponent<AudioSource>();
        mainAudioSource.playOnAwake = false;
    }

    public void PlayOneShot(string Name, float volumeScale = 1)
    {
        if (!IsOn)
            return;

        string path = ResourcesFolderName + "/" + Name;
        AudioClip clip = Resources.Load<AudioClip>(path);
        mainAudioSource.PlayOneShot(clip, volumeScale);
    }
}
