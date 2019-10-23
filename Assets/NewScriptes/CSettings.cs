using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSettings : MonoBehaviour
{
    public Toggle SoundT;

    private void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 0) {
            SoundT.isOn = false;

        }
    }

    public void SoundCheck(Toggle check) {
        if (check.isOn) {
            PlayerPrefs.SetInt("sound", 1);
            Debug.Log(1);
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
            Debug.Log(0);
        }
    }
}
