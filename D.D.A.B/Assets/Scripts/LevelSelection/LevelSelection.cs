using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {

    public int levelID;
    public bool levelUnlock = true;

    public void StartLevel()
    {
        if(levelUnlock)
        {
            SceneManager.LoadScene("Level" + levelID);
        }
    }
}
