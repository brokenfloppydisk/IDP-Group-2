using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Keypad : MonoBehaviour
{
    private static Keypad _instance;
    public static Keypad Instance {
        get {
            if (_instance == null) {
                Debug.Log("Keypad is null");
            }
            return _instance;
        } set{}
    }
    public KeypadPuzzle puzzle;
    public int value = 0;
    public Text outputText;
    public Text sideText;
    public string coordinateLabel;
    public int index;
    public Image correctLight;
    public Button enterButton;
    public Button resetButton;
    public ThoughtsTrigger thoughts;
    public void Awake() {
        _instance = this;
    }
    public void Start() {
        puzzle = KeypadPuzzle.Instance;
    }
    public void Reset() {
        value = 0;
        puzzle.values[this.index] = 0;
        outputText.text = "Z";
    }
    public void UpdateDisplay() {
        if (CameraScript.Instance.wiresConnected) {
            puzzle.values[this.index] = value;
            outputText.text = RomanNum.ToRoman(value);
            sideText.text = coordinateLabel + "-COORD";
            thoughts.sentence = "Three keypads. They seem to be for inputting coordinates of some sort.";
        }
        else {
            thoughts.sentence = "Three keypads. They don't seem to be turned on.";
            value = 0;
            puzzle.values[index] = 0;
            outputText.text = "";
            sideText.text = "";
        }
        
    }
    public void checkCorrect() {
        if (puzzle.correctValues[this.index]==value) {
            puzzle.successes[this.index] = true;
            correctLight.sprite = puzzle.lightImages[1];
            puzzle.keypadImages[this.index].sprite = puzzle.keypadSprites[1];
            resetButton.interactable = false;
            enterButton.interactable = false;
        }
        puzzle.checkCompletion();
    }
    public void close() {
        puzzle.animator.SetBool("KeypadOpen", false);
    }
    public static void DestroySingleton() {
        Instance = null;
        _instance = null;
    }
}
