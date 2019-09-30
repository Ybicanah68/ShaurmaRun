using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh()
    {
        SceneManager.LoadScene("firstLevel");
    }

    public void Menu()
    {
        SceneManager.LoadScene("main");
    }
}
