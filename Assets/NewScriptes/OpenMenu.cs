using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public GameObject openmemu;

    public void CloseMenu()
    {
        Destroy(openmemu);
    }
    public void RefreshLevel()
    {
        PlayerPrefs.DeleteKey("health");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
