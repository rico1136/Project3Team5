using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float timeLeft;
    public GameObject fill;
    float maxTime;
    [HideInInspector]
    public bool hasWalked = false;
    public bool paused;

    private void Start()
    {
        maxTime = timeLeft;
    }
    public void Update()
    {
        if (hasWalked)
        {
            if (!paused)
            {
                timeLeft -= Time.deltaTime;
            }
            
            fill.GetComponent<Image>().fillAmount = (timeLeft / maxTime);
            if (timeLeft < 0)
            {
                SecondFase();
            }
        }
    }

    private void SecondFase() 
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
    }


    
}
