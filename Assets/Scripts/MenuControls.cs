using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("levels");
    }

    public void UpgradePressed()
    {
        SceneManager.LoadScene("upgrade");
    }

    public void SkinsPressed()
    {
        SceneManager.LoadScene("skins");
    }

    public void DonatePressed()
    {
        SceneManager.LoadScene("donate");
    }

    public void HelpPressed()
    {
        SceneManager.LoadScene("help");
    }

    public void SettingsPressed()
    {
        SceneManager.LoadScene("settings");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
