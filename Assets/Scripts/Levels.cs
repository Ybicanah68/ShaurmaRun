using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public void LevelPressed()
    {
        SceneManager.LoadScene("firstLevel");
    }

    public void BactToMenu()
    {
        SceneManager.LoadScene("main");
    }
}
