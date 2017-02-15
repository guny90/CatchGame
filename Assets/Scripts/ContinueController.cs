using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueController : MonoBehaviour {

    public GameObject cat;
    public GameObject continueButton;
    public GameObject gameOverButton;
    public GameObject restartButton;
    
    public void Continue()
    {
        GameController.isAlive = true;
        cat.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        continueButton.SetActive(false);
        restartButton.SetActive(false);
        gameOverButton.SetActive(false);
    }
    
}
