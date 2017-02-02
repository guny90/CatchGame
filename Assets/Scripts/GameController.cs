using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject fish;
    public GameObject meat;
    public GameObject sushi;
    public Text timer;
    public GameObject gameOverText;
    public GameObject restartButton;

    private int food;
    private float timeLeft;
    private float maxWidth;
    public int absSeconds, minutes, seconds;

    private void Start()
    {
        if(cam == null)
        {
            cam = Camera.main;
        }
        
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float fishWidth = fish.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - fishWidth;
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        UpdateTime();
    }

    IEnumerator Spawn()
    {

        yield return new WaitForSeconds(1.0f);
        while(timeLeft < 10)
        {
            Vector3 spawnPosition = new Vector3(
            Random.Range(-maxWidth, maxWidth),
            transform.position.y-4,
            0.0f);
            Quaternion spawnRotation = Quaternion.AngleAxis(180, spawnPosition);
            
            food = Random.Range(0, 171);
            if(food >=0 && food <=75) Instantiate(fish, spawnPosition, spawnRotation);
            else if(food > 75 && food <= 130) Instantiate(meat, spawnPosition, spawnRotation);
            else Instantiate(sushi, spawnPosition, spawnRotation);
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
