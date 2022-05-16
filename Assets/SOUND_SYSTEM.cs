using UnityEngine;
using System.Collections;

public class SOUND_SYSTEM : MonoBehaviour
{
    public static SOUND_SYSTEM Instance;
    public AudioSource ads, adsBG, adsHit;
    public AudioClip[] clips;
    public AudioClip[] clipsHit;
    public static bool isSOUND = false;
    bool hited = false;


    public void MUSIC()
    {
        if (isSOUND)
            adsBG.Pause();
        else
            adsBG.Play();
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        isSOUND = true;
    }

    void Play(int index)
    {
        if (!isSOUND)
            return;
        ads.PlayOneShot(clips[index]);
    }

    public void OnClick()
    {
        Play(0);
    }

    public void Jump()
    {
        Play(1);
    }

    public void Explosion()
    {
        Play(2);
    }

    public void PlayWin()
    {
        Play(3);
    }

    public void OnPlayerHit()
    {
        if (hited)
            return;
        hited = true;
        adsHit.PlayOneShot(clipsHit[IndexClip(clipsHit.Length)]);
        StartCoroutine(delayOnPlayerHit());
    }

    IEnumerator delayOnPlayerHit()
    {
        yield return new WaitForSecondsRealtime(5F);
        hited = false;
    }

    int IndexClip(int count)
    {
        return Random.Range(1, count) - 1;
    }
}
