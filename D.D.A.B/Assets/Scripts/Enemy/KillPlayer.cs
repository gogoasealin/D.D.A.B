using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private GameObject gameController;
    private GameController gameManagerScript;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameManagerScript = gameController.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManagerScript.GameOver();
        }
    }
}
