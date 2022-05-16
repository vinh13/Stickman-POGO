using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobController : MonoBehaviour
{
	private BannerView bannerView;
	private InterstitialAd interstitial;
	string banner = "";
	string fullbanner = "";

	public void HideBanner ()
	{
		if (this.bannerView != null) {
			this.bannerView.Hide ();
		}
	}

	public void ShowBanner ()
	{
		if (this.bannerView != null) {
			this.bannerView.Show ();
		}
	}

	private AdRequest CreateAdRequest ()
	{
		return new AdRequest.Builder ().Build ();
	}

	public void RequestBanner ()
	{
		if (this.bannerView == null) {
			this.bannerView = new BannerView (banner, AdSize.SmartBanner, AdPosition.Bottom);
			// Register for ad events.
			this.bannerView.OnAdLoaded += this.HandleAdLoaded;
			this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
			this.bannerView.OnAdOpening += this.HandleAdOpened;
			this.bannerView.OnAdClosed += this.HandleAdClosed;
			this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;
			// Load a banner ad.
			this.bannerView.LoadAd (this.CreateAdRequest ());
			this.HideBanner ();
		}
	}

	public void initAdmob_ (string _banner, string _full)
	{
		this.banner = _banner;
		this.fullbanner = _full;
		this.RequestBanner ();
		this.RequestInterstitial ();
	}

	public void RequestInterstitial ()
	{
		this.interstitial = new InterstitialAd (fullbanner);
		// Register for ad events.
		this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
		this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
		this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
		this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
		this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
		// Load an interstitial ad.
		this.interstitial.LoadAd (this.CreateAdRequest ());
	}

	public void ShowInterstitial ()
	{
		if (this.interstitial != null) {
			this.interstitial.Show ();
			this.RequestInterstitial ();
		}
	}

	public bool FullbannerReady ()
	{
		return this.interstitial.IsLoaded ();
	}

	#region Banner callback handlers

	public void HandleAdLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdLoaded event received");
	}

	public void HandleAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print ("HandleFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleAdOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdOpened event received");
	}

	public void HandleAdClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdClosed event received");
	}

	public void HandleAdLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleAdLeftApplication event received");
	}

	#endregion

	#region Interstitial callback handlers

	public void HandleInterstitialLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialLoaded event received");
	}

	public void HandleInterstitialFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print (
			"HandleInterstitialFailedToLoad event received with message: " + args.Message);
	}

	public void HandleInterstitialOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialOpened event received");
		Time.timeScale = 0;
	}

	public void HandleInterstitialClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialClosed event received");


	}

	public void HandleInterstitialLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleInterstitialLeftApplication event received");
	}

	#endregion

	#region Native express ad callback handlers

	public void HandleNativeExpressAdLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdLoaded event received");
	}

	public void HandleNativeExpresseAdFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print (
			"HandleNativeExpressAdFailedToReceiveAd event received with message: " + args.Message);
	}

	public void HandleNativeExpressAdOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdOpened event received");
	}

	public void HandleNativeExpressAdClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdClosed event received");
	}

	public void HandleNativeExpressAdLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleNativeExpressAdAdLeftApplication event received");
	}

	#endregion

	#region RewardBasedVideo callback handlers

	public void HandleRewardBasedVideoLoaded (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoLoaded event received");
	}

	public void HandleRewardBasedVideoFailedToLoad (object sender, AdFailedToLoadEventArgs args)
	{
		MonoBehaviour.print (
			"HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
	}

	public void HandleRewardBasedVideoOpened (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoOpened event received");
	}

	public void HandleRewardBasedVideoStarted (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoStarted event received");
	}

	public void HandleRewardBasedVideoClosed (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoClosed event received");
	}

	public void HandleRewardBasedVideoRewarded (object sender, Reward args)
	{
		string type = args.Type;
		double amount = args.Amount;
		MonoBehaviour.print (
			"HandleRewardBasedVideoRewarded event received for " + amount.ToString () + " " + type);
	}

	public void HandleRewardBasedVideoLeftApplication (object sender, EventArgs args)
	{
		MonoBehaviour.print ("HandleRewardBasedVideoLeftApplication event received");
	}

	#endregion

}
