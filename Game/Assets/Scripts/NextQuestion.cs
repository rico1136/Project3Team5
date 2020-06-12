using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextQuestion : MonoBehaviour
{
    public GameObject question;
    public GameObject reaction;
    public QuestionManager questionManager;

    public Transform Button1;
    public Transform Button2;
    public Transform Button3;

    string Option1;
    string Option2;
    string Option3;
    private void Start()
    {
        Option1 = Button1.name;
        Option2 = Button2.name;
        Option3 = Button3.name;
    }
    public void nextQuestion() 
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        questionManager.changeReactionText(name);
        Inventory inventory = Inventory.instance;
        Item item = null;
        if (name == Option1)
        {
            item = questionManager.questions[questionManager.currentQuestion].answer1Item;
        }
        else if (name == Option2)
        {
            item = questionManager.questions[questionManager.currentQuestion].answer2Item;
        }
        if (item != null)
        {
            Debug.Log(item);
            inventory.items.Remove(item);
        }
        question.SetActive(false);
        reaction.SetActive(true);
        questionManager.currentQuestion += 1;
    }

    public void nextDilemma() 
    {
        question.SetActive(true);
        reaction.SetActive(false);
    }
}
