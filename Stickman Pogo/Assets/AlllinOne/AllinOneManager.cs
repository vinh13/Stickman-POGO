using UnityEngine;
using System.Collections;
public class AllinOneManager : MonoBehaviour
{
	[Header ("Admob Banner Defaulf-------------------                   ---------------------")]
	[SerializeField]string admobIdBanerDefult;
	[Header ("Admob Interstitial Defaulf--------------                   ---------------------")]
	[SerializeField]string admobIdInterstitialDefult;
	[Header ("Unity Ads------------------------                   ---------------------")]
	[SerializeField]string unityADS_ID;
	[Header ("LEADERBOARD-----------------------                   ---------------------")]
	public LeaderboardEntry[] leaderboardIDs;
	bool TheFirstPlayGame = false;
	void Awake ()
	{
		TheFirstPlayGame = (PlayerPrefs.GetInt ("TheFirstPlayGame") == 0) ? true : false;
		if (TheFirstPlayGame) {
			PlayerPrefs.SetInt ("TheFirstPlayGame", 1);
		}
	}
	void Start ()
	{
		AllInOne.Instance.InitunityAds (unityADS_ID);
		AllInOne.Instance.setLeadboardId (leaderboardIDs);
		AllInOne.Instance.isTheFirstPlayGame = TheFirstPlayGame;
		AllInOne.Instance.loadAdmob (admobIdBanerDefult, admobIdInterstitialDefult);
		//AllInOne.Instance._OnLoginLB ();
	}

}
