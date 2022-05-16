using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UI.Pagination;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    public static Manager Instance
    {
        get{ return instance; }
    }


    void OnValidate()
    {
        if (textCOIN == null)
        {
            Debug.LogError("Manager textCOIN null! ");
        }
    }

    #region COIN_MANAGER

    private int COIN = 0;
    public int COIN_DEFAULT = 500;
    [SerializeField]Text textCOIN = null;


    public void LoadCoin()
    {
        COIN = PlayerPrefs.GetInt("COIN", COIN_DEFAULT);
        textCOIN.text = "" + COIN;
    }

    public bool CheckBuy(int price)
    {
        if (COIN >= price)
        {
            UpdateCOIN(-price);
            return true;
        }
        else
        {
            ShowNotEnoughCoin();
            return false;
        }
    }

    public void UpdateCOIN(int value)
    {
        COIN += value;
        textCOIN.text = "" + COIN;
        PlayerPrefs.SetInt("COIN", COIN);
        PlayerPrefs.Save();


    }

    public GameObject HUD_COIN;

    public void ShowHUD_COIN()
    {
        HUD_COIN.SetActive(true);
    }

    public void HideHUD_COIN()
    {
        HUD_COIN.SetActive(false);
    }

    #endregion



    #region Awake

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


        LoadCoin();
    }

    #endregion

    #region OnSceneLoaded

    public int CurrentIndexScene = 0;
    public bool inGame = false;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrentIndexScene = scene.buildIndex;
        inGame = CurrentIndexScene == 1 ? true : false;
        if (loadingShow)
            HideLoading();
    }

    #endregion

    #region Loading Effect

    [SerializeField]AnimatorPopUpScript UILoading;
    bool loadingShow = false;

    public void ShowLoading()
    {
        
        UILoading.gameObject.SetActive(true);
        UILoading.show();
        loadingShow = true;
    }

    public void HideLoading()
    {
        UILoading.hide();
        loadingShow = false;
    }

    #endregion

    #region LoadLevel

    private string loadProgress = "Loading...";
    private string lastLoadProgress = null;
    public bool loadSceneNow = false;

    private IEnumerator LoadRoutine(int indexScene, bool _allowSceneActivation)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(indexScene);
        op.allowSceneActivation = _allowSceneActivation;
        while (!op.isDone)
        {
            if (op.progress < 0.9f)
            {
                loadProgress = "Loading: " + (op.progress * 100f).ToString("F0") + "%";
            }
            else
            { 
                loadProgress = "Loading ready for activation, Press any key to continue";
                if (loadSceneNow)
                {
                    op.allowSceneActivation = true;
                }
            }
            if (lastLoadProgress != loadProgress)
            {
                lastLoadProgress = loadProgress;
                Debug.Log(loadProgress);
            } // Don't spam console.
            yield return null;
        }
        loadProgress = "Load complete.";
        Debug.Log(loadProgress);
    }

    public void LoadSceneAuto(int indexScene)
    {
        StartCoroutine(LoadRoutine(indexScene, true));
    }

    public void LoadSceneActivate(int indexScene)
    {
        ShowLoading();
        StartCoroutine(LoadRoutine(indexScene, false));
    }

    #endregion



    #region NOT ENOUGH COIN

    [Header("NOT ENOUGH COIN")]
    public AnimatorPopUpScript UINotEnoughCoin;

    public void ShowNotEnoughCoin()
    {
        UINotEnoughCoin.gameObject.SetActive(true);
        UINotEnoughCoin.show();
    }

    public void HideNotEnoughCoin()
    {
        UINotEnoughCoin.hide();
    }

    #endregion




    #region UIPurchase COIN

    [Header("UIPurchase COIN")]
    public AnimatorPopUpScript UIPurchase;

    public void ShowPurchaseCoin()
    {
        Logic.PAUSE();
        UIPurchase.gameObject.SetActive(true);
        UIPurchase.show();
    }

    public void HidePurchaseCoin()
    {
        Logic.UNPAUSE();

        SOUND_SYSTEM.Instance.OnClick();
        UIPurchase.hide();
    }

    #endregion

    #region UIGif

    [Header("UIGif")]
    public AnimatorPopUpScript UIGif;

    public void ShowGif()
    {
        SOUND_SYSTEM.Instance.OnClick();
        UIGif.gameObject.SetActive(true);
        UIGif.show();
    }

    public void HideGif()
    {
        SOUND_SYSTEM.Instance.OnClick();
        UIGif.hide();
    }

    #endregion

    #region UIWatchVideo

    [Header("UI Watch Video")]
    public AnimatorPopUpScript UIWatchVideo;

    public RandomCoin randomCoin;

    public bool x2Coin = false;

    public void OnUnityComplete()
    {
        if (!x2Coin)
        {
            randomCoin.StartAnim();
        }
        else
        {
            HUDManager.Instance.OnUnityADSComplete();
            x2Coin = false;
        }
    }

    public void ShowUIWatchVideo()
    {

        SOUND_SYSTEM.Instance.OnClick();
        Logic.PAUSE();

        UIWatchVideo.gameObject.SetActive(true);
        UIWatchVideo.show();
    }

    public void HideUIWatchVideo()
    {
        SOUND_SYSTEM.Instance.OnClick();

        Logic.UNPAUSE();

        UIWatchVideo.hide();
    }

    #endregion

    #region Button Watch Video

    [Header("Button Watch Video")]
    public GameObject btnWatchVideo;

    public void CheckStatusButtonWatchVideo()
    {
        btnWatchVideo.SetActive(AllInOne.Instance.CheckUnityADS());   
    }

    public void ButtonVideo(bool status)
    {
        btnWatchVideo.SetActive(status);
    }

    #endregion

}
