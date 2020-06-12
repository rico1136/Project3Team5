using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("tutorialNeeded", 1);
        PlayerPrefs.SetInt("playerPoints", 0);
    }
}