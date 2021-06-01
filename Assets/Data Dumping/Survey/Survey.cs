using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Survey : MonoBehaviour
{
    [SerializeField]
    private InputField inputField = null;
    private string username = null;
    private int[] answers = new int[2];
    [SerializeField]
    private string[] textAnswers = new string[3];
    private string[] intQuestions = new string[] {
        "From a scale from 1 (unsatisfactory) to 5 (entertaining), how would you rate your experience with the escape room overall?",
        "From a scale from 1 (not ready) to 5 (ready), how ready do you think the app is to go to market?"
    };
    private string[] textQuestions = new string[] {
        "What was the best part of the app?",
        "How can the app improve?",
        "Do you have any other comments, questions, or concerns?"
    };
    [SerializeField]
    private Text numQuestionText = null;
    [SerializeField]
    private Text openEndedQuestionText = null;
    [SerializeField]
    private string answer = null;
    [SerializeField]
    private GameObject[] surveyParts = new GameObject[3];
    public int questionNum = 0;
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
        textAnswers[questionNum] = "No Answer Given.";
        inputField.text = "";
        if (questionNum == 2) {
            questionNum++;
            openEndedQuestionText.text = "";
            answer = "";
            surveyParts[3].SetActive(false);
            submitFeedback();
        } else {
            questionNum++;
            openEndedQuestionText.text = textQuestions[questionNum];
            answer = "";
        }
    }
    public void setTextAnswer() {
        textAnswers[questionNum] = answer;
        inputField.text = "";
        if (questionNum == 2) {
            surveyParts[3].SetActive(false);
            submitFeedback();
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
        CameraScript.Instance.CalculateTimes();
        CameraScript.Instance.ResetVars();
        SceneManager.LoadScene("MainMenu");
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
        if (username == "") {
            username = "Unknown";
        }
        DataDump.Initialize();
        List<object> surveyAnswers = new List<object>();
        surveyAnswers.Add(username);
        surveyAnswers.Add(answers[0]);
        surveyAnswers.Add(answers[1]);
        for (int i = 0; i < 3; i++) {
            surveyAnswers.Add(textAnswers[i]);
        }
        DataDump.CreateEntry("A","F",surveyAnswers, 1);
        CameraScript.Instance.CalculateTimes(username);
        
    }
    public void MainMenu() {
        CameraScript.Instance.ResetVars();
        SceneManager.LoadScene("MainMenu");
    }

}
