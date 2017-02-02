using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 offset = new Vector3(0.0f, 2.0f, 0.0f);
            GameObject clone = (GameObject)Instantiate(explosion, transform.position - offset, transform.rotation);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 20.0f;
            //Destroy(collision.gameObject, 0.5f);
            Destroy(gameObject,0.5f);
            Destroy(clone, 1.2f);
        }
    }
    
}
