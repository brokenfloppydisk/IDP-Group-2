using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : MonoBehaviour
{
    public bool answer;
    private CommandConsole commandConsole;
    private void Start() {
        commandConsole = CommandConsole.Instance;
    }
    public void Click() {
        if (commandConsole.areYouSureOpen) {
            if (answer) {
                commandConsole.checkAnswer();
            }
            else {
                commandConsole.selectedAnswer = null;
                commandConsole.TriggerText();
            }
            commandConsole.areYouSureOpen = false;
        }
        else if (answer) {
            commandConsole.textManager.next();
        }
        else if (!answer) {
            commandConsole.closeMenu();
        }
    }
}
