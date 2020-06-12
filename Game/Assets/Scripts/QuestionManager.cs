using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class QuestionManager : MonoBehaviour
{
    [Header("Questions")]
    public List<Question> questions;
    public int currentQuestion = 0;
    public Transform answersParent;
    public TMP_Text question;
    public nextScene nextScene;

    [Header("Buttons")]
    public Transform button1;
    public Transform button2;
    public Transform button3;
    public Sprite defaultIcon;

    [Header("Other")]
    public TMP_Text reaction;

    [Header("Inventory")]
    Inventory inventory;
    bool loading = false;

    string Option1;
    string Option2;
    string Option3;

    Transform[] answers;

    private void Start()
    {
        Option1 = button1.name;
        Option2 = button2.name;
        Option3 = button3.name;
        answers = answersParent.GetComponentsInChildren<Transform>();
        inventory = Inventory.instance;
    }

    private void Update()
    {
        if (currentQuestion >= questions.Count)
        {
            if (!loading)
            {
                Destroy(GameObject.Find("GameManager"));
                Destroy(Inventory.instance);
                nextScene.aSyncLoadLevel();
                loading = true;
             
            }
            return;
        }

        question.text = questions[currentQuestion].question;
        if (inventory.items.Contains(questions[currentQuestion].answer1Item))
        {
            answers[2].gameObject.GetComponent<Image>().sprite = questions[currentQuestion].answer1Item.icon;
            answers[1].gameObject.GetComponent<Button>().enabled = true;
        }
        else
        {
            answers[2].gameObject.GetComponent<Image>().sprite = questions[currentQuestion].answer1Item.noItemIcon;
            answers[1].gameObject.GetComponent<Button>().enabled = false;
        }

        if (inventory.items.Contains(questions[currentQuestion].answer2Item))
        {
            answers[4].gameObject.GetComponent<Image>().sprite = questions[currentQuestion].answer2Item.icon;
            answers[3].gameObject.GetComponent<Button>().enabled = true;
        }
        else
        {
            answers[4].gameObject.GetComponent<Image>().sprite = questions[currentQuestion].answer2Item.noItemIcon;
            answers[3].gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void changeReactionText(string buttonName) 
    {
        int points = PlayerPrefs.GetInt("playerPoints");
        if (buttonName == Option1)
        {
            reaction.text = questions[currentQuestion].answer1Text;
            PlayerPrefs.SetInt("playerPoints", points + 10);
        }
        else if (buttonName == Option2)
        {
            reaction.text = questions[currentQuestion].answer2Text;
            PlayerPrefs.SetInt("playerPoints", points + 5);
        }
        else if (buttonName == Option3)
        {
            reaction.text = questions[currentQuestion].answer3Text;
            PlayerPrefs.SetInt("playerPoints", points + 0);
        }
    }
}
