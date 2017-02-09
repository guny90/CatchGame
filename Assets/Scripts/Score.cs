using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int fishValue, meatValue, sushiValue;

    private int score;
    
	void Start () {
        score = GameController.score;
        UpdateScore();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fish")) score += fishValue;
        else if (collision.CompareTag("meat")) score += meatValue;
        else if (collision.CompareTag("sushi")) score += sushiValue;

        transform.position = new Vector3(transform.position.x, -3.14f, transform.position.z);
        transform.rotation = Quaternion.identity;
        //GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        UpdateScore();
    }

    void UpdateScore()
    {
        GameController.score = score;
        scoreText.text = "Score\n" + score;
    }
}
