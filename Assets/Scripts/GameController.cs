using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject[] foods;
    public Text timer;
    public GameObject gameOverText;
    public GameObject restartButton;

    private int randomIndex;
    private int food;
    private float timeLeft;
    private float maxWidth;
    public int absSeconds, minutes, seconds;
    public static bool isAlive;

    private void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }

        isAlive = true;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float foodWidth = foods[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - foodWidth;
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        UpdateTime();
    }

    IEnumerator Spawn()
    {

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
            if(food.CompareTag("dog")) spawnRotation = Quaternion.AngleAxis(0, spawnPosition);
            Instantiate(food, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
        }
        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        restartButton.SetActive(true);
    }

    void UpdateTime()
    {
        
        if(!restartButton.activeSelf)
        {
            timeLeft += Time.deltaTime;
        }
        absSeconds = Mathf.RoundToInt(timeLeft);
        minutes = absSeconds / 60;
        seconds = absSeconds % 60;
        timer.text = "Time\n" + (minutes>9 ? "" : "0" ) + 
            minutes + " : " + (seconds>9 ? "" : "0") + seconds;
    }
}
