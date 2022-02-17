using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizDetailsManager : MonoBehaviour
{
    [SerializeField]
    private Text txtQuizTitle;//Quiz Title
    [SerializeField]
    QuestionItem prefabQuestionItem;//Questions prefab
    [SerializeField]
    List<QuestionItem> questionItemList;//List contains questions instantiated
    [SerializeField]
    Transform targetQuestionItemListPos;//Parent of question items
    [SerializeField]
    Button btnPreview;//button for Preview Quiz

    void Start()
    {
        //Initialize UI items
        SetQuizTitle();
        GenerateQuestionList(AppDataManager.Instance._quizTemp);
    }

    //Set current quiz title
    void SetQuizTitle()
    {
        if(txtQuizTitle) txtQuizTitle.text = "Title : " + AppDataManager.Instance._quizTemp.quizTitle;
    }

    //Generate existing questions
    void GenerateQuestionList(AppData.QuizDetails thisQuizDetails)
    {
        if(thisQuizDetails != null && thisQuizDetails.questionList.Count > 0)
        {
            for(int i = 0; i < thisQuizDetails.questionList.Count;i++)
            {
                var quizClone = Instantiate(prefabQuestionItem, targetQuestionItemListPos);
                quizClone.Init(thisQuizDetails.questionList[i], i+1);
                quizClone.gameObject.SetActive(true);
            }

            //Enable if there is any question
            btnPreview.gameObject.SetActive(true);
        } else
        {
            //Disable if there are no question
            btnPreview.gameObject.SetActive(false);
        }
    }

    //Load scene Question_Details
    public void AddQuestion()
    {
        SceneManager.LoadScene("Question_Details");
    }

    //Load scene Quiz_Preview
    public void PreviewQuestion()
    {
        SceneManager.LoadScene("Quiz_Preview");
    }
}
