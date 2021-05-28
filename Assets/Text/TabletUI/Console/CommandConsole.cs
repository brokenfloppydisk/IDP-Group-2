using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
#pragma warning disable 0649
public class CommandConsole : TextTrigger
{
    public Animator[] screenAnimators;
    [SerializeField]
    private TextObject correctAnswerText;
    [SerializeField]
    private TextObject incorrectAnswerText;
    [SerializeField]
    private TextObject areYouSureText;
    public int correctAnswerNum;
    private ConsoleButton[] consoleButtons;
    private GameTimer gameTimer;
    public ConsoleButton selectedAnswer;
    private List<ConsoleButton> unselectedAnswers = new List<ConsoleButton>();
    public bool menuOpen;
    public bool areYouSureOpen;
    public GameObject openConsoleButton;
    public bool puzzleComplete = false;
    public GameObject openConsoleButton2;
    private void Start() {
        consoleButtons = FindObjectsOfType<ConsoleButton>();
        gameTimer = FindObjectOfType<GameTimer>();
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
        gameTimer.AddPenalty(1);
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
        if (openConsoleButton) {
            openConsoleButton.SetActive(false);
        }
        openConsoleButton2.SetActive(true);
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
}
