using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

    public Camera cam;
    public Rigidbody2D rb2d;

    private bool facingRight;

	// Use this for initialization
	void Start () {
        facingRight = true;
		if(cam == null)
        {
            cam = Camera.main;
            rb2d = GetComponent<Rigidbody2D>();
        }
	}
	
	// Update is called once per physics timestep
	void FixedUpdate () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, -3.11f, 0.0f);
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
