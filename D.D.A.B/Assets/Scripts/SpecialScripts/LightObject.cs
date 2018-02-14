using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        }
    }
}
