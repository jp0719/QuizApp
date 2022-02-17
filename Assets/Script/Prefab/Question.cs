using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    private Text txtQuestionTitle;//Text for question title
    [SerializeField]
    private List<Text> txtOption;//Text for each options
    [SerializeField]
    private ToggleGroup toggleGroupQuestionOptions;//Toggle group for options
    [SerializeField]
    private List<Toggle> toggleQuestionOptions;//List contains each options
    [SerializeField]
    private Text txtButtonNext;//Text for button Next

    //Setup information in Question
    public void Init(AppData.QuestionDetails thisQuestionDetails)
    {
        if (txtQuestionTitle) txtQuestionTitle.text = thisQuestionDetails.questionTitle;
        for(int i = 0; i < thisQuestionDetails.optionText.Count;i++)
        {
            if (txtOption[i]) txtOption[i].text = thisQuestionDetails.optionText[i];
            if (txtQuestionTitle)txtButtonNext.text = i + 1 == thisQuestionDetails.optionText.Count ? "Submit" : "Next";
        }
    }

    //Get toggled option index
    public int GetAnswerIndex()
    {
        for (int i = 0; i < toggleQuestionOptions.Count; i++)
        {
            if (toggleQuestionOptions[i].isOn) { return i; }
        }
        return -1;
    }
}
