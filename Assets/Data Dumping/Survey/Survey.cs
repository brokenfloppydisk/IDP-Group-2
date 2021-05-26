using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#pragma warning disable 0649
public class Survey : MonoBehaviour
{
    private CameraScript cameraScript;
    private string username;
    private int[] answers = new int[2];
    private string[] textAnswers = new string[3];
    private string[] intQuestions = new string[] {
        "From a scale from 1 (bad) to 5 (good), how would you rate the escape room overall?",
        "From a scale from 1 (not ready) to 5 (ready), how ready do you think the app is to go to market?",
    };
    private string[] textQuestions = new string[] {
        "What was the best part of the app?",
        "How can the app improve?",
        "Do you have any other comments, questions, or concerns?"
    };
    [SerializeField]
    private Text numQuestionText;
    [SerializeField]
    private Text openEndedQuestionText;
    private string answer;
    [SerializeField]
    private InputField nameField;
    [SerializeField]
    private InputField reccomendationsField;
    [SerializeField]
    private GameObject[] surveyParts = new GameObject[3];
    public int questionNum = 0;
    private void Awake() {
        cameraScript = FindObjectOfType<CameraScript>();
    }
    public void TakeSurvey() {
        surveyParts[0].SetActive(false);
    }
    public void GetName() {
        surveyParts[1].SetActive(false);
    }
    public void setUserName(string name) {
        username = name;
    }
    public void skipUserName() {
        username = "Unknown";
        surveyParts[1].SetActive(false);
    }
    public void setAnswer(string answer) {
        this.answer = answer;
    }
    public void skipTextAnswer() {
        textAnswers[questionNum] = " ";
        if (questionNum == 2) {
            surveyParts[3].SetActive(false);
        } else {
            questionNum++;
            openEndedQuestionText.text = textQuestions[questionNum];
            answer = "";
        }
    }
    public void setTextAnswer() {
        textAnswers[questionNum] = answer;
        if (questionNum == 2) {
            surveyParts[3].SetActive(false);
        } else {
            questionNum++;
            openEndedQuestionText.text = textQuestions[questionNum];
            answer = "";
        }
    }
    public void skipNumberAnswer() {
        answers[questionNum] = -1;
        if (questionNum == 1) {
            surveyParts[2].SetActive(false);
            questionNum = 0;
        } else {
            questionNum++;
            numQuestionText.text = intQuestions[questionNum];
        }
    }
    public void DontTakeSurvey() {
        cameraScript.CalculateTimes();
        cameraScript.ResetVars();
        SceneManager.LoadScene("Main Menu");
    }
    public void setValue(int answer) {
        answers[questionNum] = answer;
        if (questionNum == 1) {
            surveyParts[2].SetActive(false);
            questionNum = 0;
        } else {
            questionNum++;
            numQuestionText.text = intQuestions[questionNum];
        }
    }
    public void submitFeedback() {
        DataDump.Initialize();
        List<object> surveyAnswers = new List<object>();
        surveyAnswers.Add(answers[0]);
        surveyAnswers.Add(answers[1]);
        for (int i = 0; i < 3; i++) {
            surveyAnswers.Add(textAnswers[i]);
        }
        DataDump.CreateEntry("A","E",surveyAnswers, 1);
        cameraScript.CalculateTimes(username);
        cameraScript.ResetVars();
        SceneManager.LoadScene("MainMenu");
    }

}
