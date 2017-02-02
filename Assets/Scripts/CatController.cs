﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

    private Camera cam;
    private Rigidbody2D rb2d;
    private float maxWidth;
    private bool facingRight;

	// Use this for initialization
	void Start () {
        facingRight = true;
		if(cam == null)
        {
            cam = Camera.main;
        }
        rb2d = GetComponent<Rigidbody2D>();
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float catWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - catWidth;
    }
	
	// Update is called once per physics timestep
	void FixedUpdate () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, transform.position.y, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        rb2d.MovePosition(targetPosition);
        Flip(rawPosition.x);
	}

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal <=0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
