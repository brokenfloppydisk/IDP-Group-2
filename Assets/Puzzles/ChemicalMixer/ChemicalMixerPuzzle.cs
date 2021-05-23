using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChemicalMixerPuzzle : MonoBehaviour
{
    public List<ChemicalMixerValue> chemicalMixerValues = new List<ChemicalMixerValue>();
    public List<int> correctValues = new List<int>();
    public bool puzzleComplete;
    public Animator animator;
    public Image tntImage;
    public bool tntSelected;
    public bool tntInCup;
    public Color highlightedColor;
    public Color convertedColor;
    [System.NonSerialized]
    public Color normalColor;
    public Animator GUIAnimator;
    public GameObject tntDeskImage;
    private void Awake() {
        normalColor = tntImage.color;
    }
    public void checkComplete() {
        int successes = 0;
        if (tntInCup) {
            for (int i = 0; i < chemicalMixerValues.Count; i++) {
                if (chemicalMixerValues[i].value == correctValues[i]) {
                    successes++;
                }
            }
            if (successes == 3) {
                puzzleComplete = true;
                tntInCup = false;
                tntImage.color = convertedColor;
            }
        }  
    }
    public void selectTnt() {
        if (!tntSelected) {
            tntImage.color = highlightedColor;
            tntSelected = true;
        } else {
            tntImage.color = normalColor;
            tntSelected = false;
        }
    }
    public void pressOnCup() {
        if (tntSelected) {
            tntInCup = true;
            tntSelected = false;
            tntImage.color = normalColor;
            tntImage.gameObject.transform.position += new Vector3(-115,45,0);
        }
        if (puzzleComplete) {
            GUIAnimator.SetBool("TNTAcquired", true);
            tntImage.gameObject.transform.position = new Vector3(0, -9000, 0);
            tntDeskImage.SetActive(false);
        }
    }
    public void openPuzzle() {
        animator.SetBool("MixerOpen", true);
    }
    public void closePuzzle() {
        animator.SetBool("MixerOpen", false);
    }
}
