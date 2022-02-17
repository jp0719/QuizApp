using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionItem : MonoBehaviour
{
    [SerializeField]
    private Text questionIndex;//Text for question number in table
    [SerializeField]
    private Text questionTitle;//Text for question title

    //Setup information for questions in table
    public void Init(AppData.QuestionDetails thisQuestionDetails, int index)
    {
        if (questionTitle) questionTitle.text = thisQuestionDetails.questionTitle;
        if (questionIndex) questionIndex.text = index.ToString();
    }
}
