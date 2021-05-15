using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System;
//using System.Collections.Generic;

public class FacebookManager : MonoBehaviour {

	private void Awake ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}	
	
	
	public void Share() {
		
//		FB.ShareLink(
//			new Uri("https://developers.facebook.com/"),
//			callback: ShareCallback
//		);


                FB.FeedShare(
                    string.Empty,
                    new Uri("http://rwdesenv.neocities.org/4ckids.html"),
                    "4C Kids",
                    "★★★★★ 4C Kids ★★★★★",
                    "★★★★★ 4C Kids ★★★★★",
                    new Uri("https://rwdesenv.neocities.org/192.png"),
                    string.Empty,
                    this.HandleResult);		
/*
		FB.ShareLink(
			 new Uri("https://rwdesenv.neocities.org/4ckids.html"),
			 callback: ShareCallback
		 );
*/
	}
	
	private void ShareCallback (IShareResult result) {
		if (result.Cancelled || !String.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
		} else if (!String.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
		} else {
			// Share succeeded without postID
			Debug.Log("ShareLink success!");
		}
	}		

	protected void HandleResult(IResult result)
	{
	}
	
}
