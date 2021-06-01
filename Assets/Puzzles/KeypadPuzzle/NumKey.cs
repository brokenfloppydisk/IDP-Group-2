using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumKey : MonoBehaviour
{
    private Keypad keypad;
    public int addValue; 
    private void Start() {
        keypad = Keypad.Instance;
    }
    public void Add() {
        if (keypad.value < 1000) {
            keypad.value = 10 * keypad.value + addValue;
            keypad.UpdateDisplay();
        }
    }
}
