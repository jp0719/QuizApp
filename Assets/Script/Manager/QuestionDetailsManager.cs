using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionDetailsManager : MonoBehaviour
{
    [SerializeField]
    private InputField inputQuestionTitle;//Inputfield of question title
    [SerializeField]
    private List<InputField> inputQuestionOptions;//List of inputfield of option text
    [SerializeField]
    private ToggleGroup toggleGroupQuestionOptions;//Toggle group for question's options
    [SerializeField]
    private List<Toggle> toggleQuestionOptions;//List of toggle of question's options

    [SerializeField]
    AppData.QuestionDetails _questionDetails;//Temporary question data

    //Save question data and merge into quiz list
    public void SaveQuestion()
    {

        _questionDetails = new AppData.QuestionDetails();
        _questionDetails.questionId = AppDataManager.Instance._quizTemp.questionList.Count + 1;
        _questionDetails.optionText = new List<string>();

        //If question is not inserted
        if (string.IsNullOrEmpty(inputQuestionTitle.text))
        {
            PopUpManager.Instance.showMessage("Question cannot be empty.");
            return;
        }
        _questionDetails.questionTitle = inputQuestionTitle.text;
        foreach (InputField input in inputQuestionOptions)
        {
            //If option input is not inserted
            if (string.IsNullOrEmpty(input.text))
            {
                PopUpManager.Instance.showMessage("Option text cannot be empty.");
                return;
            }
            _questionDetails.optionText.Add(input.text);
        }
        _questionDetails.correctIndex = GetAnswerIndex();

        AppDataManager.Instance._quizTemp.questionList.Add(_questionDetails);
        AppDataManager.Instance.OverwriteQuizDetailsById(AppDataManager.Instance._quizTemp);
        AppDataManager.Instance.SaveAppDataToJSON();
        SceneManager.LoadScene("Quiz_Details");
    }

    //Get toggled option index
    int GetAnswerIndex()
    {
        for (int i = 0; i < toggleQuestionOptions.Count; i++)
        {
            if (toggleQuestionOptions[i].isOn) { return i; }
        }
        return -1;
    }
}
