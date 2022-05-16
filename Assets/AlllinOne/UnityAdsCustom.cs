using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdsCustom : MonoBehaviour
{
    public void InitUnityADS(string adUnitId)
    {
        #if UNITY_EDITOR
        string _adUnitId = "1262015";
        #else
		string _adUnitId = adUnitId;
        #endif
        Advertisement.Initialize(_adUnitId, true);
    }

    public void ShowAd(string zone = "")
    {
        #if UNITY_EDITOR
        //	StartCoroutine (WaitForAd ());
        #endif
        if (string.Equals(zone, ""))
            zone = null;
        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone))
        {
            Advertisement.Show(zone, options);
        }
    }

    public bool checkUnityADsReady()
    {
        return Advertisement.IsReady("");
    }

    void AdCallbackhandler(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                AllInOne.Instance.OnUnityComplete();
                break;
            case ShowResult.Skipped:
                AllInOne.Instance.OnUnitySkip();
                break;
            case ShowResult.Failed:
			//			Debug.Log("I swear this has never happened to me before");
			//			AndroidMessage.Create("FAIL TO LOAD VIDEO"," Please check your internet connection.");
                break;
        }
    }

    IEnumerator WaitForAd()
    {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;
        Time.timeScale = currentTimeScale;
    }
    //	IEnumerator delayGetCoin ()
    //	{
    //		yield return new WaitForSecondsRealtime (0.5f);
    //		SoundAndMusicPower.Instance.playClipCoin ();
    //		CoinManager.Instance.AddCoin (100);
    //	}
}
