using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotWire : ConnectPuzzle {
    private CameraScript cameraScript;
    public Image statusLight;
    public Sprite[] statusLightStates;
    public List<Animator> animators;
    public ThoughtsTrigger thoughts;
    private void Awake() {
        cameraScript = FindObjectOfType<CameraScript>();
        if (cameraScript.wiresConnected) {
            enterButton.interactable = false;
            resetButton.interactable = false;
            statusLight.sprite = statusLightStates[1];
            thoughts.sentence = "A set of connected electrical wires.";
            FindObjectOfType<Keypad>().thoughts.sentence = "Three keypads. They seem to be for inputting coordinates of some sort.";
        }
    }
    public void openPuzzle() {
        puzzleReset();
        setAnimationParam("PuzzleOpen",true);
    }
    public void closePuzzle() {
        puzzleReset();
        setAnimationParam("PuzzleOpen",false);
    }
    public void activateShip() {
        enterButton.interactable = false;
        resetButton.interactable = false;
        statusLight.sprite = statusLightStates[1];
        cameraScript.wiresConnected = true;
        KeypadPuzzle _keypadPuzzle = FindObjectOfType<KeypadPuzzle>();
        for (int i = 0; i < _keypadPuzzle.keypadImages.Count; i++) {
            _keypadPuzzle.keypadImages[i].sprite = _keypadPuzzle.keypadSprites[0];
        }
        thoughts.sentence = "A set of connected electrical wires.";
        FindObjectOfType<Keypad>().thoughts.sentence = "Three keypads. They seem to be for inputting coordinates of some sort.";
    }
    public void setAnimationParam(string param, bool value) {
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetBool(param, value);
        }
    }
    public void checkCompletion() {
        if (puzzleComplete != true) {
            int successes = 0;
            for (int i = 0; i < topNodes.Count; i++) {
                if (topNodes[i].success) { successes++; }
            }
            if (successes >= topNodes.Count) {
                activateShip();
                puzzleComplete = true;
            }
        }
    }
}
