using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LeaderboardEntry
{
    public string leaderboardID;
    public string keyPrefs;
}

public class AllInOne : MonoBehaviour
{
    private static AllInOne instance;
    public int countAdmob = 0;


    public bool TapToPlay = true;


    public static AllInOne Instance
    {
        get
        { 
            return instance;
        }
    }

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
        isLeaderboardLogin = false;
        countAdmob = PlayerPrefs.GetInt("CountADS");
        countBanner = PlayerPrefs.GetInt("countBanner");
    }

    [SerializeField]
    AdmobController admobController;
    [SerializeField]
    UnityAdsCustom unityadsCustom;
    [SerializeField][Header("Android ==> Add Component now!")]
    LeaderboardCustomAndroid lbAndroid;
    [SerializeField][Header("IOS ==> Add Component now!")]
    LeaderboardCustomIOS lbIOS;
    LeaderboardEntry[] lbentry;
    public bool isLeaderboardLogin = false;
    public bool isTheFirstPlayGame = false;

    public bool removeADS = false;

    int tempADS = 0;


    public void GetRemoveADS()
    {
        removeADS = (PlayerPrefs.GetInt("removeAds") == 0) ? false : true;
    }

    void Start()
    {
        removeADS = (PlayerPrefs.GetInt("removeAds", 0) == 0) ? false : true;
        tempADS = countAdmob;
        tempADS += Random.Range(3, 5);
    }

    public void setLeadboardId(LeaderboardEntry[] temp)
    {
        this.lbentry = temp;
    }

    public void submitScore()
    {
        if (!isLeaderboardLogin)
            return;
        if (lbAndroid != null)
        {
            for (int i = 0; i < lbentry.Length; i++)
            {
                lbAndroid.SummitScores(lbentry[i].leaderboardID, lbentry[i].keyPrefs);
            }
        }
        else if (lbIOS != null)
        {
            for (int i = 0; i < lbentry.Length; i++)
            {
                lbIOS.SummitScores(lbentry[i].leaderboardID, lbentry[i].keyPrefs);
            }
        }
    }

    int countBanner = 0;

    public void RemoveAllAds()
    {
        if (removeADS)
            return;
        this.HideAdmobBanner();
        removeADS = true;
        PlayerPrefs.SetInt("removeAds", 1);
        PlayerPrefs.Save();
    }

    public void loadAdmob(string _banner, string fullbanner_)
    {
        admobController.initAdmob_(_banner, fullbanner_);
    }

    public void ShowAdmobBanner()
    {
        admobController.ShowBanner();
        //   PlayerPrefs.SetInt("countBanner", countBanner);
    }

    public void HideAdmobBanner()
    {
        admobController.HideBanner();
    }

    public void ShowAdmobFULL()
    {
        if (removeADS)
            return;
        countAdmob += 1;
        if (countAdmob <= tempADS)
            return;
        tempADS += 3;
        admobController.ShowInterstitial();
        PlayerPrefs.SetInt("CountADS", countAdmob);
    }

    public void InitunityAds(string idunityADs)
    {
        unityadsCustom.InitUnityADS(idunityADs);
    }

    public void showUnityAds()
    {
        unityadsCustom.ShowAd("");
    }

    public void _OnLoginLB()
    {
        #if UNITY_EDITOR
        print("Login Leaderboard");
        #elif UNITY_ANDROID
		lbAndroid.LoginLB();
        #elif UNITY_IPHONE
		lbIOS.LoginLB();
        #endif
    }

    public void _OnShowLB()
    {
        #if UNITY_EDITOR
        print("Show LB");
        #elif UNITY_ANDROID
		lbAndroid.OnShowLeaderBoard();
        #elif UNITY_IPHONE
		lbIOS.showLeaderBoardsUI();
        #endif
    }

    #region CallBack

    public void OnUnityComplete()
    {
        Manager.Instance.OnUnityComplete();
    }

    public void OnUnitySkip()
    {
        Manager.Instance.OnUnityComplete();
    }

    public bool CheckUnityADS()
    {
        return unityadsCustom.checkUnityADsReady();
    }

    #endregion
}
