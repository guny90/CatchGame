using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class WatchAdAndContinue : MonoBehaviour {

    public GameObject continueButton, adButton;

    public void WatchAnAdd()
    {
        continueButton.SetActive(true);
        ShowRewardedAd();
        adButton.SetActive(false);
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameController.isRewarded = true;
                Debug.Log("The ad was successfully shown." + GameController.isRewarded);
                break;
            case ShowResult.Skipped:
                GameController.isRewarded = false;
                Debug.Log("The ad was skipped before reaching the end." + GameController.isRewarded);
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                GameController.isRewarded = false;
                break;
        }
    }
}
