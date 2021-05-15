using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAppStore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    public void Open() {
        #if UNITY_ANDROID
            Application.OpenURL("market://dev?id=8661706558284396298"); // Application.OpenURL ("market://search?q=rwdesenv");
        #elif UNITY_IPHONE
            Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID"); // Application.OpenURL("https://itunes.apple.com/us/app/apple-store/idYOUR_ID?mt=8");  
        #endif
    }	

	
}
