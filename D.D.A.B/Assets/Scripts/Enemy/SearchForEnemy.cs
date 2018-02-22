using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SearchForEnemy : MonoBehaviour {

    private GameObject[] enemys;
    private bool destroy;
    private GameObject gameManager;
    private GameManager gameManagerScript;


    private void Awake()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager != null)
        {
            gameManagerScript = gameManager.GetComponent<GameManager>();
        }
    }


    void Update () {
        destroy = true;
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i] != null)
            {
                destroy = false;
            }
        }
        if (destroy)
        {
            GoToNextLevel();
        }
    }


    void GoToNextLevel()
    {
        int levelMax = 0;
        if (gameManagerScript != null)
        {
            gameManagerScript.Load(ref levelMax);
        }
        Scene scene = SceneManager.GetActiveScene();
        string nextLevel = scene.name;
        string nextLevelName = nextLevel.Substring(nextLevel.Length - 1);
        int lvlnumber = int.Parse(nextLevelName);
        lvlnumber++;
        int levelReached = lvlnumber;

        if (gameManagerScript != null)
        {
            if (levelReached > levelMax)
            {
                gameManagerScript.Save(levelReached);
            }
        }
        SceneManager.LoadScene("level" + lvlnumber);
    }
}
