using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizItem : MonoBehaviour
{
    [SerializeField]
    private Text _txtNo;//Text of quiz number in table
    [SerializeField]
    private Text _txtQuizTitle;//Text of quiz title
    [SerializeField]
    private int _id;
    [SerializeField]
    private string _quizTitle;
    MainManager _mainManager;

    //Script reference and setup information of each quiz item
    public void Init(MainManager thisMainManager,int thisId, string thisQuizTitle,int index)
    {
        _mainManager = thisMainManager;
        _id = thisId;
        _quizTitle = thisQuizTitle;
        if (_txtNo) _txtNo.text = index.ToString();
        if (_txtQuizTitle) _txtQuizTitle.text = thisQuizTitle;
    }
}
