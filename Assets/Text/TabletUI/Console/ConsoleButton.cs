using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleButton : MonoBehaviour
{
    public int answerNum;
    private CommandConsole commandConsole;
    private void Start() {
        commandConsole = FindObjectOfType<CommandConsole>();
    }
    public void click() {
        if (commandConsole.menuOpen) {
            commandConsole.selectedAnswer = this;
            commandConsole.areYouSure();
        }
    }
}