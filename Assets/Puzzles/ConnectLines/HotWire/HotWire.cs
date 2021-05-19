using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotWire : HotWirePuzzle
{
    private CameraScript vars;
    public Image statusLight;
    public Sprite[] statusLightStates;
    public List<Animator> animators;
    void Awake() {
        vars = FindObjectOfType<CameraScript>();
    }
    public void openPuzzle()
    {
        puzzleReset();
        setAnimationParam("PuzzleOpen",true);
    }
    public void closePuzzle()
    {
        puzzleReset();
        setAnimationParam("PuzzleOpen",false);
    }
    public void activateShip()
    {
        
        enterButton.interactable = false;
        resetButton.interactable = false;
        statusLight.sprite = statusLightStates[1];
    }
    public void setAnimationParam(string param, bool value)
    {
        for (int i = 0; i < animators.Count; i++)
        {
            animators[i].SetBool(param, value);
        }
    }

    public void checkCompletion()
    {
        if (puzzleComplete != true)
        {
            int successes = 0;
            for (int i = 0; i < topWires.Count; i++)
            {
                if (topWires[i].success) { successes++; }
            }
            if (successes >= topWires.Count)
            {
                activateShip();
                puzzleComplete = true;
            }
        }

    }
}
