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
    public GameObject itemDescriptions;
    public ThoughtsTrigger tntDescription;
    private void Awake() {
        normalColor = tntImage.color;
    }
    private void Start() {
        if (FindObjectOfType<CameraScript>().firstDoorExploded == true)
        {
            tntImage.gameObject.transform.position = new Vector3(0, -9000, 0);
            FindObjectOfType<TNT>().ReturnToRoom();
            tntDeskImage.SetActive(false);
            GUIAnimator.SetBool("PuzzleAlreadyFinished", true);
        }
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
            tntDeskImage.gameObject.transform.position = new Vector3(193,-32,0);
            tntDeskImage.gameObject.transform.eulerAngles = new Vector3(0,25,0);
            tntDeskImage.gameObject.transform.localScale = new Vector3(0.4f,0.3f,1);
        }
        if (puzzleComplete) {
            GUIAnimator.SetBool("TNTAcquired", true);
            tntImage.gameObject.transform.position = new Vector3(0, -9000, 0);
            tntDeskImage.SetActive(false);
            tntDescription.sentence = "According to the recipe, this explosive should now be strong enough...";
        }
    }
    public void openPuzzle() {
        itemDescriptions.gameObject.transform.position += new Vector3(0, -1000, 0);
        animator.SetBool("MixerOpen", true);
    }
    public void closePuzzle() {
        itemDescriptions.gameObject.transform.position += new Vector3(0, 1000, 0);
        animator.SetBool("MixerOpen", false);
    }
}
