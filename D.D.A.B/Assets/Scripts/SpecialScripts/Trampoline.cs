using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public int bouncing;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 velocity = other.gameObject.GetComponent<Rigidbody2D>().velocity;
            velocity += new Vector3(0, bouncing, 0);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        }

    }
}
