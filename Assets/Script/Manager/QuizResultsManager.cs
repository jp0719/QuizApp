using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizResultsManager : MonoBehaviour
{
    [SerializeField]
    private Text txtResult;//Text for preview result


    void Start()
    {
        //Display result on start
        DisplayPreviewQuizResult(AppDataManager.Instance.correctCount, AppDataManager.Instance._quizTemp.questionList.Count);
    }

    //Display result
    void DisplayPreviewQuizResult(int thisCorrectCount, int thisTotalCount)
    {
        if(txtResult)txtResult.text = "Your Score : " + thisCorrectCount + "/" + thisTotalCount;
    }

    //Load scene Quiz_Details
    public void BackToQuizDetails()
    {
        SceneManager.LoadScene("Quiz_Details");
    }
}
