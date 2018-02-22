using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

    [SerializeField] private Vector3 nextPosition;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Shuriken")
        {
            player.gameObject.transform.position = nextPosition;
            Destroy(other.gameObject);
        }
    }
}
