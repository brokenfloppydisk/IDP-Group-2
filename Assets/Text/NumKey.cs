using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumKey : Keypad
{
    private Keypad keypad;
    public int addValue; 

    void Awake() {
        keypad = FindObjectOfType<Keypad>();
    }
    
    public void Add() {
        if (keypad.value < 1000) {
            keypad.value = 10*keypad.value + addValue;
            keypad.outputText.text = RomanNum.ToRoman(keypad.value); 
        }
    }
}
