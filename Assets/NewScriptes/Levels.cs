using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public int level;
    public GameObject[] buttons;

    private void Start()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            level = 1;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i >= level) {
                buttons[i].GetComponent<Image>().color = new Color(255, 0, 0);
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void LevelPressed(GameObject levelButton)
    {
         SceneManager.LoadScene(levelButton.name);
    }

    public void BactToMenu()
    {
        SceneManager.LoadScene("main");
    }
}
