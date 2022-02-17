using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewQuizManager : MonoBehaviour
{
    [SerializeField]
    private InputField inputQuizName;//Inputfield for new quiz name

    //Create and add new quiz into existing list
    public void SaveName()
    {
        if (!string.IsNullOrEmpty(inputQuizName.text))
        {
            AppDataManager.Instance.CreateNewQuizWithName(inputQuizName.text);
            AppDataManager.Instance.AddNewQuizIntoList();
            AppDataManager.Instance.SaveAppDataToJSON();
            SceneManager.LoadScene("Quiz_Details");//Load scene Quiz_Details
        }
        else
        {
            PopUpManager.Instance.showMessage("Quiz Name cannot be empty.");
        }
    }
}
