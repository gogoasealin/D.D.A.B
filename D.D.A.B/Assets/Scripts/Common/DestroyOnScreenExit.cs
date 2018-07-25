using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnScreenExit : MonoBehaviour {

    private GameObject gameController;
    private GameController gameControllerScript;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        gameControllerScript.GameOver();
    }
}
