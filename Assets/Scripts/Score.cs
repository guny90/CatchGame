using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int fishValue, meatValue, sushiValue;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fish")) score += fishValue;
        else if (collision.CompareTag("meat")) score += meatValue;
        else if (collision.CompareTag("sushi")) score += sushiValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score\n" + score;
    }
}
