using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Shuriken")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
