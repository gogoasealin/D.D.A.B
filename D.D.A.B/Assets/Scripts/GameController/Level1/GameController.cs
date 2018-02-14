﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class GameController : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerControllerScript;
    public GameObject GameOverWindow;
    public GameObject PauseWindow;
    public GameObject backToMenuButton;

    private GameObject gameManager;
    private GameManager gameManagerScript;
    public int count;
    public int highScore;
    public int numberOfAllGames;
    public bool gameOver;
    public int levelReached;
    public int currentLevelReached;

    //private PlayAdd playAdd;
    public bool pause;

    void Awake()
    {
        //gameManager = GameObject.FindGameObjectWithTag("GameManager");
        //gameManagerScript = gameManager.GetComponent<GameManager>();
        playerControllerScript = player.GetComponent<PlayerController>();
        //gameManagerScript.Load();

        //playAdd = GetComponent<PlayAdd>();
        //playAdd.InitializeAdd();


        PrepareGame();

    }  



    public void CheckGameOver()
    {
        if (!gameOver)
        {
            StopAllCoroutines();
        }
    }

    public void GameOver()
    {
        if (gameOver)
        {
            gameOver = false;
            playerControllerScript.enabled = false;
            Destroy(player);
            //numberOfAllGames += 1;
            //if (highScore < count)
            //{
            //    //new record
            //    highScore = count;
            //}
            EnableMenuText();
            // gameManagerScript.Save();
            if (GameOverWindow != null)
            {
                GameOverWindow.SetActive(true);
            }
            //if (numberOfAllGames >= 10)
            //{
            //    numberOfAllGames = 0;
            //    //playAdd.ShowAd();
            //}
            //else
            //{
            //    GameOverWindow.SetActive(true);
            //}

        }
    }

    public void EnableMenuText()
    {
        // poate timer pe stelute? 
        if (backToMenuButton != null)
        {
            backToMenuButton.SetActive(true);
        }

    }

    public void DisableMenuText()
    {
        backToMenuButton.SetActive(false);
    }

    public void RestartButton()
    {
        GameOverWindow.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("" + scene.name); // current scene 

    }

    public void Pause()
    {
        Time.timeScale = 0;
        EnableMenuText();
        PauseWindow.SetActive(true);

    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        DisableMenuText();
        PauseWindow.SetActive(false);
        playerControllerScript.resume = false;
    }

    public void PrepareGame()
    {
        Time.timeScale = 1;
        gameOver = true;
        pause = false;
        GameOverWindow.SetActive(false);
        PauseWindow.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    public void SwitchPause()
    {
        if (playerControllerScript != null && playerControllerScript.enabled)
        {
            if (playerControllerScript.pause)
            {
                playerControllerScript.pause = false;
                playerControllerScript.resume = true;
            }
            else if (!playerControllerScript.pause)
            {
                playerControllerScript.pause = true;
            }
        }
    }


}