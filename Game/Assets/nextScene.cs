using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class nextScene : MonoBehaviour
{
    public int sceneIndex;
    public GameObject loadingScreen;
    public Slider slider;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void aSyncLoadLevel() 
    {
        StartCoroutine(LoadAsyncronously(sceneIndex));
    }

    IEnumerator LoadAsyncronously(int sceneIndex) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);
        
        while (!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
    public void goToNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
