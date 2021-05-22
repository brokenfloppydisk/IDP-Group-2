using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenConsoleButton : MonoBehaviour
{
    private CommandConsole commandConsole;
    private void Awake() {
        commandConsole = FindObjectOfType<CommandConsole>();
    }
    public void Click() {
        commandConsole.openConsoleButton = gameObject;
        commandConsole.openMenu();
        gameObject.SetActive(false);
    }
}
