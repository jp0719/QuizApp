using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private Transform targetQuizListPos;//Parent of quiz items
    [SerializeField]
    private QuizItem prefabQuizItem;//Quiz prefab
    [SerializeField]
    private List<QuizItem> _quizItemList;//List of quiz instantiated

    void Start()
    {
        //Generate quiz list if quiz exists
        if (AppDataManager.Instance.GetQuizList() != null)
        {
            GenerateQuizList(AppDataManager.Instance.GetQuizList());
        }
    }

    //Generate quiz
    void GenerateQuizList(AppData.QuizList _quizList)
    {
        int index = 1;
        if(_quizList.quiz.Count > 0)
        {
            foreach (AppData.QuizDetails q in _quizList.quiz)
            {
                var quizClone = Instantiate(prefabQuizItem, targetQuizListPos);
                quizClone.Init(this, q.quizId, q.quizTitle, index);
                quizClone.gameObject.SetActive(true);
                _quizItemList.Add(quizClone);
                index++;
            }
        }
    }

    //Load scene New_Quiz
    public void CreateQuiz()
    {
        SceneManager.LoadScene("New_Quiz");
    }
}
