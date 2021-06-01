using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenConsoleButton : MonoBehaviour
{
    private CommandConsole commandConsole;
    public TextObject text;
    private void Start() {
        commandConsole = CommandConsole.Instance;
    }
    public void Click() {
        commandConsole.openMenu();
        gameObject.SetActive(false);
    }
    public void Click2() {
        commandConsole.screenAnimators[0].SetBool("MenuOpen", true);
        commandConsole.screenAnimators[1].SetBool("MenuButtonsActive", true);
        commandConsole.menuOpen = true;
        commandConsole.TriggerText(text);
    }
}
