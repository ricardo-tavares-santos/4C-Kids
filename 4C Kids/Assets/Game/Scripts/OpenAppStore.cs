using UnityEngine;
using System.Collections;

public class OpenAppStore : MonoBehaviour {

    void Start() {

    }

    public void Open() {
 //       #if UNITY_ANDROID 
              Application.OpenURL("https://play.google.com/store/apps/dev?id=8661706558284396298");  // Application.OpenURL("market://dev?id=8661706558284396298"); // Application.OpenURL ("market://search?q=rwdesenv");
 //       #elif UNITY_IPHONE
 //           Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID"); // Application.OpenURL("https://itunes.apple.com/us/app/apple-store/idYOUR_ID?mt=8");  
 //       #endif
    }
	
    public void OpenPageGame() {
              Application.OpenURL("https://play.google.com/store/apps/details?id=com.RWdesenv.CKids"); 
    }	
    
}