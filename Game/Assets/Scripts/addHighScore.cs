using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class addHighScore : MonoBehaviour
{
    Highscores highscoresManager;
    public InputField user;
    public GameObject bedanktScherm;
    private void Start()
    {
        highscoresManager = GetComponent<Highscores>();
    }
    public void onButtonPress() 
    {
        int points = PlayerPrefs.GetInt("playerPoints");
        if (user.text == null)
        {
            return;
        }
        highscoresManager.AddNewHighscore(user.text, points);
        bedanktScherm.SetActive(false);
    }

    public void restartGame(){
        Destroy(GameObject.Find("PlayerPrefs"));
        SceneManager.LoadScene(0); 
    }
    public void quitGame() {
        Application.Quit(); 
    }


}
