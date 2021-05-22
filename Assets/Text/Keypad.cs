using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Keypad : MonoBehaviour
{
    public int value = 0;
    public Text outputText;
    public void Reset() {
        value = 0;
        outputText.text = "";
    }
}
