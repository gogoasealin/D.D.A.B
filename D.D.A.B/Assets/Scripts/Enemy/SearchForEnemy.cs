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
        gameManagerScript = gameManager.GetComponent<GameManager>();
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
        Scene scene = SceneManager.GetActiveScene();
        string nextLevel = scene.name;
        string nextLevelName = nextLevel.Substring(nextLevel.Length - 1);
        int lvlnumber = int.Parse(nextLevelName);
        lvlnumber++;
        int levelReached = lvlnumber;

        gameManagerScript.Save(levelReached);
        if (lvlnumber == 6)
        {
            SceneManager.LoadScene("End");
        }
        else SceneManager.LoadScene("level" + lvlnumber);
    }
}
