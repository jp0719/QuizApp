using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData : MonoBehaviour
{
    //Object class for Quiz List
    [Serializable]
    public class QuizList
    {
        public List<QuizDetails> quiz;
    }

    //Object class for each Quiz
    [Serializable]
    public class QuizDetails
    {
        public int quizId;
        public string quizTitle;
        public List<QuestionDetails> questionList;
    }

    //Object class for Questions in Quiz
    [Serializable]
    public class QuestionDetails
    {
        public int questionId;
        public string questionTitle;
        public List<string> optionText;
        public int correctIndex;
    }

}
