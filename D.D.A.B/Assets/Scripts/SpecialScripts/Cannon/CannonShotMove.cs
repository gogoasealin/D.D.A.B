using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShotMove : MonoBehaviour {
    private Rigidbody2D rb2d;

    [SerializeField]private float speed = 200;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce((transform.up + transform.right) * speed);
        rb2d.angularVelocity = 200f;
    }


    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
