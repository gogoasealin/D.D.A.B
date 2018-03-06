using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSoloBrick : MonoBehaviour {

    private float moveSpeed = 0.8f;
    private bool go;
    private Vector3 goPosition;

    private void Awake()
    {
        goPosition = gameObject.transform.position + new Vector3(0F, -100f, 0f);
    }

    private void Update()
    {
        if (go)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, goPosition, Time.deltaTime * moveSpeed);
        }       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            go = true;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
