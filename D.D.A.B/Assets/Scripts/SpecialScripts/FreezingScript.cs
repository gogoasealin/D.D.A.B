using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingScript : MonoBehaviour {

    [SerializeField] private float MaxTimingBeforeDie;
    private float timer;
    private GameObject gameController;
    private GameController gameControllerScript;
    private GameObject player;
    private PlayerController playerControllerScript;


    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerControllerScript = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > MaxTimingBeforeDie)
        {
            gameControllerScript.GameOver();
        }
        //if timer == maxTiming/2
        //player.animation freezing
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            timer = 0;
            //player.animation unfreezing
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            timer = 0;
        }
    }

}
