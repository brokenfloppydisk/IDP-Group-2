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
    [SerializeField]
    private List<ThoughtsTrigger> thoughtsTriggers = new List<ThoughtsTrigger>();
    private void Awake() {
        normalColor = tntImage.color;
    }
    private void Start() {
        if (CameraScript.Instance.firstDoorExploded == true) {
            tntImage.gameObject.transform.position = new Vector3(0, -10000, 0);
            TNT.Instance.ReturnToRoom();
            tntDeskImage.SetActive(false);
            GUIAnimator.SetBool("PuzzleAlreadyFinished", true);
            thoughtsTriggers[2].sentence = "I've already made the explosive. There's no point in using this now.";
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
                thoughtsTriggers[0].Trigger();
                Hints.Instance.sceneIndexer.UpdateIndex(4);
            }
        } else {
            thoughtsTriggers[2].Trigger();
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
            thoughtsTriggers[2].sentence = "Now that the explosive is in the cup, what should I use for the recipe...";
            thoughtsTriggers[2].Trigger();
        }
        if (puzzleComplete) {
            GUIAnimator.SetBool("TNTAcquired", true);
            tntImage.gameObject.transform.position = new Vector3(0, -10000, 0);
            tntDeskImage.SetActive(false);
            tntDescription.sentence = "According to the recipe, this explosive should now be strong enough...";
            thoughtsTriggers[1].Trigger();
        }
    }
    public void openPuzzle() {
        itemDescriptions.gameObject.transform.position += new Vector3(0, -10000, 0);
        animator.SetBool("MixerOpen", true);
        if (!tntInCup) {
            thoughtsTriggers[2].Trigger();
        }
    }
    public void closePuzzle() {
        itemDescriptions.gameObject.transform.position += new Vector3(0, 10000, 0);
        animator.SetBool("MixerOpen", false);
    }
}
