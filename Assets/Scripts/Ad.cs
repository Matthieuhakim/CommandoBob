using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ad : MonoBehaviour
{
    public static Ad instance;
    private InterstitialAd interstitial;
    private bool weDidIt = false;


    void Start()
    {
        RequestInterstitial();
        
    }
    void Update()
    {
        if(ComandoController.didCollide && !weDidIt){
            ShowAd();
            weDidIt = true;
        }
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-1043453206087483/7122700608";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void ShowAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }


    }

    public void DestroyInterstitial(){
        interstitial.Destroy();
    }
   

}
