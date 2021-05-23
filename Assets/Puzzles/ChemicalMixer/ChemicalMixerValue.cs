using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemicalMixerValue : MonoBehaviour
{
    [System.NonSerialized]
    public ChemicalMixerPuzzle puzzle;
    public int value=1;
    public Text text;
    public string chemical;
    public void Add() {
        if (value < 16) {
            value ++;
        }
        updateText();
    }
    public void Subtract() {
        if (value > 0) {
            value--;
        }
        updateText();
    }
    public void Start() {
        updateText();
    }
    public void updateText() {
        text.text = chemical + ": " + RomanNum.ToRoman(value);
    }
}
