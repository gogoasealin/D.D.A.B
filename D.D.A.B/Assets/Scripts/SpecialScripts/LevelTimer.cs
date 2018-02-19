﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    public float levelTimer;
    public Text levelTimerText;
    private float timer;
    private GameObject gameController;
    private GameController gameControllerScript;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        gameControllerScript = gameController.GetComponent<GameController>();
        timer = levelTimer;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        levelTimerText.text = timer.ToString("F2");
        if (timer <= 0)
        {
            levelTimerText.text = "";
            gameControllerScript.GameOver();
            Destroy(gameObject.GetComponent<LevelTimer>());
        }
    }
}
