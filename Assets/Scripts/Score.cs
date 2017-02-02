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
        string colName = collision.gameObject.name;
        if(colName.Contains("fish"))
        {
            score += fishValue;
        } else if(colName.Contains("meat"))
        {
            score += meatValue;
        } else if(colName.Contains("sushi"))
        {
            score += sushiValue;
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score:\n" + score;
    }
}
