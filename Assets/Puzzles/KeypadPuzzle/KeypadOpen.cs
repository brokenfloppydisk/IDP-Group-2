using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadOpen : MonoBehaviour
{
    [System.NonSerialized]
    public KeypadPuzzle puzzle;
    public int index;
    public void Awake() {
        puzzle = FindObjectOfType<KeypadPuzzle>();
    }
    public void openKeypad() {
        puzzle.animator.SetBool("KeypadOpen", true);
        puzzle.keypad.index = this.index;
        if (puzzle.successes[this.index]) {
            puzzle.keypad.correctLight.sprite = puzzle.lightImages[1];
        } else {
            puzzle.keypad.correctLight.sprite = puzzle.lightImages[0];
        }
        puzzle.keypad.enterButton.interactable = !puzzle.successes[this.index];
        puzzle.keypad.resetButton.interactable = !puzzle.successes[this.index];
        puzzle.keypad.value = puzzle.values[index];
        puzzle.keypad.coordinateLabel = puzzle.coordinates[index];
        if (puzzle.cameraScript.wiresConnected) {
            puzzle.keypad.outputText.text = RomanNum.ToRoman(puzzle.keypad.value);
            puzzle.keypad.sideText.text = puzzle.coordinates[index] + "-COORD";
        } else {
            puzzle.keypad.value = 0;
            puzzle.values[index] = 0;
            puzzle.keypad.outputText.text = "";
            puzzle.keypad.sideText.text = "";
        }
    }
}
