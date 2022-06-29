using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int level1 = 1;
        SceneManager.LoadScene(level1);
    }
    public void LoadLevel2()
    {
        int levelTwoScene = 2;
        SceneManager.LoadScene(levelTwoScene);
    }

    public void ReLoadLevel()
    {
        int thisScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(thisScene);
    }
    public void HomeScreen()
    {
        Manager.manager.audios[3].Play();
        SceneManager.LoadScene(0);
    }

}
