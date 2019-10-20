using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameOver : MonoBehaviour
{
    public void RefreshLevel()
    {
        PlayerPrefs.DeleteKey("health");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    public void BactToMenu()
    {
        SceneManager.LoadScene("main");
    }
}
