using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public float timeLeft = 120f;
    public TMP_Text textComponent;

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        textComponent.text = Mathf.Round(timeLeft) + " secondes";
        if (timeLeft < 0)
        {
            SecondFase();
        }
    }

    private void SecondFase() 
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
    }


    
}
