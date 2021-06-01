using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class CommandConsole : TextTrigger
{
    private static CommandConsole _instance;
    public static CommandConsole Instance {
        get {
            if (_instance == null) {
                Debug.Log("Command Console is null");
            }
            return _instance;
        } set{}
    }
    public Animator[] screenAnimators = new Animator[1];
    [SerializeField]
    private TextObject correctAnswerText = null;
    [SerializeField]
    private TextObject incorrectAnswerText = null;
    [SerializeField]
    private TextObject areYouSureText = null;
    public int correctAnswerNum = -1;
    [SerializeField]
    private ConsoleButton[] consoleButtons = new ConsoleButton[4];
    public ConsoleButton selectedAnswer = null;
    private List<ConsoleButton> unselectedAnswers = new List<ConsoleButton>();
    public bool menuOpen = false;
    public bool areYouSureOpen = false;
    public GameObject openConsoleButton = null;
    public bool puzzleComplete = false;
    public GameObject openConsoleButton2 = null;
    private void Awake() {
        _instance = this;
    }
    private void Start() {
        unselectedAnswers.AddRange(from ConsoleButton button in consoleButtons select button);
        if (CameraScript.Instance.shipActivated) {
            correct();
        }
    }
    public void openMenu() {
        screenAnimators[0].SetBool("MenuOpen",true);
        screenAnimators[1].SetBool("MenuButtonsActive", true);
        menuOpen = true;
        TriggerText();
        setConsoleButtonsActive(true);
        selectedAnswer = null;
    }
    public void closeMenu() {
        screenAnimators[0].SetBool("MenuOpen",false);
        screenAnimators[1].SetBool("MenuButtonsActive", false);
        menuOpen = false;
        setConsoleButtonsActive(false);
        selectedAnswer = null;
        if (!puzzleComplete) {
            openConsoleButton.SetActive(true);
        }
    }
    public void setConsoleButtonsActive(bool active) {
        for (int i = 0; i<consoleButtons.Length; i++) {
            consoleButtons[i].gameObject.SetActive(!active);
        }
        for (int i = 0; i < unselectedAnswers.Count; i++) {
            unselectedAnswers[i].gameObject.SetActive(active);
        }
    }
    public void incorrectAnswer(ConsoleButton consoleButton) {
        TriggerText(incorrectAnswerText);
        consoleButton.gameObject.SetActive(false);
        unselectedAnswers.Remove(selectedAnswer);
        selectedAnswer = null;
        GameTimer.Instance.AddPenalty(1);
    }
    public void correctAnswer() {
        correct();
        TriggerText(correctAnswerText);
        
    }
    public void correct() {
        puzzleComplete = true;
        CameraScript.Instance.shipActivated = true;
        setConsoleButtonsActive(false);
        unselectedAnswers.Clear();
        if (CameraScript.Instance.bayDoorOpen) {
            openConsoleButton2.GetComponent<OpenConsoleButton>().text.sentences[0] = "BAY DOOR: OPEN\nNAVIGATION: OPERATIONAL\nESCAPE PODS: OFFLINE";
        }
        openConsoleButton2.SetActive(true);
        openConsoleButton.SetActive(false);
    }
    public void areYouSure() {
        areYouSureOpen = true;
        TriggerText(areYouSureText);
    }
    public void checkAnswer() {
        areYouSureOpen = false;
        if (selectedAnswer.answerNum == correctAnswerNum) {
            correctAnswer();
        }
        else {
            incorrectAnswer(selectedAnswer);
        }
        selectedAnswer = null;
    }
    public static void DestroySingleton() {
        Instance = null;
        _instance = null;
    }
}
