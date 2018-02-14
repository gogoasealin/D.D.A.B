using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour {

    private GameObject gameManager;
    private GameManager gameManagerScript;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Scene scene = SceneManager.GetActiveScene();
            string nextLevel = scene.name;
            string nextLevelName = nextLevel.Substring(nextLevel.Length-1);
            int lvlnumber = int.Parse(nextLevelName);
            lvlnumber++;
            int levelReached = lvlnumber;

            gameManagerScript.Save(levelReached);
            SceneManager.LoadScene("level" + lvlnumber); 
        }
    }
}
