using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class NowLevel : MonoBehaviour
{
    public int level;
    public string sname;
    public string lsnumber;
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        sname = SceneManager.GetActiveScene().name;
        lsnumber = ((sname).Replace("Level", ""));
        level = Int32.Parse(lsnumber);
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = level + " уровень";
    }
}
