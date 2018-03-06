using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningShuriken : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    public bool left;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (!left)
        {
            rb2d.AddForce(transform.right * speed);
        }
        else
        {
            rb2d.AddForce(-transform.right * speed);
        }
        rb2d.angularVelocity = 200f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "Environment" || other.tag == "Breakable")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
