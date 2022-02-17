using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

//Singleton script for data within entire app
public class AppDataManager : Singleton<AppDataManager>
{

    [SerializeField]
    private AppData.QuizList _quizList;//List contains existing quiz
    [SerializeField]
    public AppData.QuizDetails _quizTemp;//Temporary object for new quiz

    private string _jsonPath;//Path of data json saved
    private int _correctCount;//Correct count for Preview Quiz
    public int correctCount
    {
        get { return _correctCount; }
        set { _correctCount = value; }
    }

    void Awake()
    {
        //Initialize default/fix data
        _correctCount = 0;
        _jsonPath = Application.persistentDataPath + "/appData.json";
        if (File.Exists(_jsonPath) && !string.IsNullOrEmpty(File.ReadAllText(_jsonPath)))
        {
            print("File Exists");
            print(File.ReadAllText(_jsonPath));
            GetAppDataFromJSON();
        }
        else
        {
            print("File Does Not Exists, Generate New Data");
            _quizList = new AppData.QuizList();
            _quizList.quiz = new List<AppData.QuizDetails>();
        }
        
    }

    //Parse and deserialize data from json
    void GetAppDataFromJSON()
    {
        _quizList = JsonUtility.FromJson<AppData.QuizList>(File.ReadAllText(_jsonPath));
    }

    public AppData.QuizList GetQuizList()
    {
        return _quizList;
    }

    //Initialize new quiz
    public void CreateNewQuizWithName(string thisQuizTitle)
    {
        int id = _quizList.quiz.Count + 1;
        _quizTemp = new AppData.QuizDetails();
        _quizTemp.questionList = new List<AppData.QuestionDetails>();
        _quizTemp.quizId = id;
        _quizTemp.quizTitle = thisQuizTitle;
    }

    //Serialize and save data into json
    public void SaveAppDataToJSON()
    {
        string jsonString = JsonUtility.ToJson(_quizList);
        File.WriteAllText(_jsonPath, jsonString);
    }

    //Add temporary quiz data into quiz list
    public void AddNewQuizIntoList()
    {
        _quizList.quiz.Add(_quizTemp);
    }

    //Merge temporary quiz data into quiz list
    public void OverwriteQuizDetailsById(AppData.QuizDetails thisQuizDetails)
    {
        if(_quizList.quiz.Count > 0)
        {
            for(int i = 0; i < _quizList.quiz.Count; i++)
            {
                if(_quizList.quiz[i].quizId == thisQuizDetails.quizId)
                {
                    _quizList.quiz[i] = thisQuizDetails;
                    return;
                }
            }
        }
    }

}
