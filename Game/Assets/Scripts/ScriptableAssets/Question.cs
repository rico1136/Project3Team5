using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Custom/Question")]
public class Question : ScriptableObject
{
    [Header("Question")]
    public string question = "New question";

    [Header("Answer1")]
    public Item answer1Item;
    public string answer1Text;

    [Header("Answer2")]
    public Item answer2Item;
    public string answer2Text;


    [Header("Answer2")]
    public string answer3Text;

}
