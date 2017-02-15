using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject[] foods;
    public Text timer;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject continueWithAdButton;
    public static int score = 0;
    public int absSeconds, minutes, seconds;
    public static bool isAlive;
    public static bool isRewarded;
    public bool spawnIsRunning;

    private int randomIndex;
    private int food;
    private float timeLeft;
    private float maxWidth;

    private void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }

        isAlive = true;
        spawnIsRunning = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float foodWidth = foods[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - foodWidth;
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        UpdateTime();

        if(isAlive && !spawnIsRunning)
        {
            StartCoroutine(Spawn());
        }
    }

    public IEnumerator Spawn()
    {
        spawnIsRunning = true;

        yield return new WaitForSeconds(1.0f);
        while(isAlive)
        {
            randomIndex = Random.Range(0, foods.Length);
            GameObject food = foods[randomIndex];
            
            Vector3 spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                    transform.position.y-4,
                    0.0f);
            Quaternion spawnRotation = Quaternion.AngleAxis(180, spawnPosition);
            if(food.CompareTag("dog"))
                spawnRotation = Quaternion.AngleAxis(0, spawnPosition);
            Instantiate(food, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.6f, 1.0f));
        }
        yield return new WaitForSeconds(1.0f);
        spawnIsRunning = false;
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1.0f);

        restartButton.SetActive(true);
        if(Advertisement.IsReady("rewardedVideo"))
        {
            continueWithAdButton.SetActive(true);
        }
        
    }

    void UpdateTime()
    {
        if(isAlive)
        {
            timeLeft += Time.deltaTime;
        }
        absSeconds = Mathf.RoundToInt(timeLeft);
        minutes = absSeconds / 60;
        seconds = absSeconds % 60;
        timer.text = "Time\n" + (minutes>9 ? "" : "0" ) + 
            minutes + " : " + (seconds>9 ? "" : "0") + seconds;
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }

    }

    
}
