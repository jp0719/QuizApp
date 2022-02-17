using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizPreviewManager : MonoBehaviour
{
    [SerializeField]
    private Text txtQuestionCount;//Text of current question count
    [SerializeField]
    private Question prefabQuestion;//Prefab of questions
    [SerializeField]
    private List<Question> questionList;//List of questions instantiated
    [SerializeField]
    private Transform targetQuestionSpawnPos;//Parent of questions
    [SerializeField]
    int questionIndex;//Current question's index
    [SerializeField]
    int correctCount;//Keep count of correct answers

    void Start()
    {
        //Initialize default data
        questionIndex = 0;
        correctCount = 0;

        //Generate all questions on start
        GenerateQuestions(AppDataManager.Instance._quizTemp);
    }

    //Generate all questions from temporary quiz 
    void GenerateQuestions(AppData.QuizDetails thisQuiz)
    {
        foreach(AppData.QuestionDetails q in thisQuiz.questionList)
        {
            var questionClone = Instantiate(prefabQuestion, targetQuestionSpawnPos);
            questionClone.Init(q);
            questionList.Add(questionClone);
        }
        //Start with first question
        ProceedNextQuestion(questionIndex);
    }

    //Proceed with next question
    void ProceedNextQuestion(int nextIndex)
    {
        if (txtQuestionCount) txtQuestionCount.text = "Question (" + (nextIndex + 1) + "/" + questionList.Count + ")";
        if (nextIndex < questionList.Count)
        {
            if (nextIndex != 0) { questionList[nextIndex - 1].gameObject.SetActive(false); }
            questionList[nextIndex].gameObject.SetActive(true);
        }
    }

    //On button Next pressed
    public void Next()
    {
        //If no option selected
        if(questionList[questionIndex].GetAnswerIndex() == -1)
        {
            PopUpManager.Instance.showMessage("Select an answer to proceed.");
            return;
        }

        //Check if answer correct
        CheckAnswer(questionList[questionIndex].GetAnswerIndex(), AppDataManager.Instance._quizTemp.questionList[questionIndex].correctIndex);

        //Proceed to next question
        if (questionIndex < questionList.Count - 1)
        {
            questionIndex++;
            ProceedNextQuestion(questionIndex);
        } else
        {
            //if there is no more question, complete the preview
            AppDataManager.Instance.correctCount = correctCount;
            SceneManager.LoadScene("Quiz_Results");
        }
    }

    //Check answer
    public void CheckAnswer(int thisSelectedOption, int thisAnswerIndex)
    {
        if (thisSelectedOption == thisAnswerIndex) correctCount++;
    }
}
