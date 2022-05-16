using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        Logic.UNPAUSE();
        Manager.Instance.ButtonVideo(true);

    }

    public void ClickPlay()
    {
        Logic.PAUSE();

        ModeManager.Instance.ShowUIMode();
        SOUND_SYSTEM.Instance.OnClick();
    }

    public void ClickVS()
    {
        SOUND_SYSTEM.Instance.OnClick();
        Manager.Instance.ShowLoading();


        Logic.NameMode = "Adventure";
        Logic.IdLevel = 10;
        StartCoroutine(delayClickVS());


    }

    public void ClickLB()
    {
        SOUND_SYSTEM.Instance.OnClick();
        AllInOne.Instance._OnShowLB();
    }

    IEnumerator delayClickVS()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        Manager.Instance.LoadSceneAuto(2);
    }

    public void ClickExit()
    {
        SOUND_SYSTEM.Instance.OnClick();
        Application.Quit();
    }

    public void ClickGif()
    {
        SOUND_SYSTEM.Instance.OnClick();
        Manager.Instance.ShowGif();

    }

    public void ClickShop()
    {
        Manager.Instance.ShowPurchaseCoin();
    }
}
