using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
