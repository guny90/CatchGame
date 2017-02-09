using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class NewBehaviourScript : MonoBehaviour {
    

#if !UNITY_ADS
    public string gameId;
    public bool enableTestMode = true;
#endif

    IEnumerator Start()
    {
#if !UNITY_ADS
        if(Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, enableTestMode);
        }
#endif

        while(!Advertisement.isInitialized || !Advertisement.IsReady())
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Show();
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
    }
}
