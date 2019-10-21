using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NewLevel : MonoBehaviour
{
    public int level;
    public int newlevel;
    public string sname;
    public string lsnumber;
    void Start()
    {
        sname = SceneManager.GetActiveScene().name;
        lsnumber = ((sname).Replace("Level", ""));
        level = Int32.Parse(lsnumber);
    }

    public void RefreshLevel()
    {
        PlayerPrefs.DeleteKey("health");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BactToMenu()
    {
        SceneManager.LoadScene("main");
    }

    public void LoanNewLevel()
    {
        newlevel = level + 1;
        if (PlayerPrefs.HasKey("level") && PlayerPrefs.GetInt("level") < newlevel)
        {
            PlayerPrefs.SetInt("level", newlevel);
        }
        SceneManager.LoadScene("Level" + newlevel);
    }
}
