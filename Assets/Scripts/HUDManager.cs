using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TungDz;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [Header("SCORE MANAGER MANAGER MANAGER")]
    public ScoreManager _ScoreManager;

    public bool isTEST = false;


    public bool endlessMode = false;

    void Awake()
    {
        Instance = this;
        Logic.IsEnd = false;
    }

    public AnimatorPopUpScript UIReady, UIWin_Lose, UIPause;

    void Start()
    {
        if (!isTEST)
        {
            Logic.PAUSE();
            UIReady.gameObject.SetActive(true);
            UIReady.hide();
            StartCoroutine(delayReady());
        }
        else
        {
            Logic.UNPAUSE();
        }
        Manager.Instance.ButtonVideo(false);

        AllInOne.Instance.HideAdmobBanner();
    }

    IEnumerator delayReady()
    {
        yield return new WaitForSecondsRealtime(4F);
        Logic.UNPAUSE();
    }

    public void OnWin()
    {
        if (Logic.IsEnd)
            return;
        Logic.IsEnd = true;
        Logic.PAUSE();

        SOUND_SYSTEM.Instance.PlayWin();

        _ScoreManager.OnWin();

        UIWin_Lose.gameObject.SetActive(true);
        UIWin_Lose.hide();


        AllInOne.Instance.ShowAdmobFULL();


        Manager.Instance.ButtonVideo(true);
    }

    public void OnLose()
    {

        if (Logic.IsEnd)
            return;
        Logic.IsEnd = true;
        Logic.PAUSE();
        UIWin_Lose.gameObject.SetActive(true);
        UIWin_Lose.hideII();
        if (endlessMode)
        {
            EndlessMode.Instance.GetPriceContinue();
        }

        AllInOne.Instance.ShowAdmobFULL();


        Manager.Instance.ButtonVideo(true);
    }


    #region PAUSE PAUSE PASE

    public void ShowPause()
    {

        SOUND_SYSTEM.Instance.OnClick();
        Logic.PAUSE();
        UIPause.gameObject.SetActive(true);
        UIPause.show();

        AllInOne.Instance.ShowAdmobBanner();
    }

    public void HidePause()
    {
        SOUND_SYSTEM.Instance.OnClick();
        Logic.UNPAUSE();
        UIPause.hide();

        AllInOne.Instance.HideAdmobBanner();
    }

    #endregion

    public void ToMenu()
    {
        SOUND_SYSTEM.Instance.OnClick();
        Manager.Instance.ShowLoading();
        StartCoroutine(delayToMenu());
        AllInOne.Instance.ShowAdmobFULL();
    }

    IEnumerator delayToMenu()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        Manager.Instance.LoadSceneAuto(0);
    }

    public void Retry()
    {
        AllInOne.Instance.ShowAdmobFULL();
        SOUND_SYSTEM.Instance.OnClick();
        Manager.Instance.ShowLoading();
        StartCoroutine(delayRetry());
    }

    IEnumerator delayRetry()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        if (!endlessMode)
        {
            Manager.Instance.LoadSceneAuto(1);
        }
        else
        {
            Manager.Instance.LoadSceneAuto(2);
        }
    }


    public void Continue()
    {


        SOUND_SYSTEM.Instance.OnClick();
        if (endlessMode)
        {
            if (EndlessMode.Instance.GetContinue())
            {
                this.PostEvent(EventID.EndlessContinue);
                HideLose();

                Manager.Instance.ButtonVideo(false);

            }
        }
        else
        {
        }

    }

    public void HideLose()
    {
        UIWin_Lose.showII();

    }

    #region NEXT LEVEL

    public void NextLevel()
    {

        AllInOne.Instance.ShowAdmobFULL();

        SOUND_SYSTEM.Instance.OnClick();
        Manager.Instance.ShowLoading();
        StartCoroutine(delayNextLevel());
    }

    IEnumerator delayNextLevel()
    {
        yield return new WaitForSecondsRealtime(0.25F);
        Logic.IdLevel++;
        if (Logic.IdLevel < Logic.NumberLevel)
        {
            Manager.Instance.LoadSceneAuto(1);
        }
        else
        {
            Logic.NameMode = "Adventure";
            Logic.IdLevel = 10;
            Manager.Instance.LoadSceneAuto(2);
        }
    }

    #endregion

    public void X2_COIN()
    {
        SOUND_SYSTEM.Instance.OnClick();
        Manager.Instance.x2Coin = true;
        AllInOne.Instance.showUnityAds();
    }

    public void OnUnityADSComplete()
    {
        _ScoreManager.X2Coin();
    }
}
