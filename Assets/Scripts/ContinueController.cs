using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueController : MonoBehaviour {

    public GameObject cat;
    public GameObject continueButton;
    public GameObject gameOverButton;


    public void Continue()
    {
        GameController.isAlive = true;
        cat.transform.position = Explode.originalPosition;
        cat.transform.rotation = Explode.originalRotation;
        cat.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        continueButton.SetActive(false);
        gameOverButton.SetActive(false);
    }




}
