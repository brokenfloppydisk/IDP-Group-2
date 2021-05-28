using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneIndexer : TextTrigger
{
    public int indexerNumber;
    public int index;
    private int usedHints = 0;
    private Hints hints;
    private int act;
    public int hintsUsed;
    [SerializeField]
    private TextObject textObject;
    public Animator animator;
    private GameTimer gameTimer;
    [SerializeField]
    [TextArea(2,10)]
    private List<string> hintsList = new List<string>() {
        "",
        "",
        "",
        ""
    };
    [SerializeField]
    private List<float> penaltyList = new List<float>() {
        1,
        2,
        3,
        4
    };
    private void Start() {
        hints = FindObjectOfType<Hints>();
        if (hints.alreadyInitializedText[indexerNumber]) {
            this.textObject = hints.textObjects[indexerNumber];
            this.usedHints = hints.usedHints[indexerNumber];
        } else {
            hints.textObjects[indexerNumber] = this.textObject;
            hintsUsed = 0;
            index = 0;
            hints.alreadyInitializedText[indexerNumber] = true;
        }
        animator = hints.animator;
        gameTimer = hints.gameTimer;
        textManager = hints.textManager;
        this.index = hints.indices[indexerNumber];
        hints.sceneIndexer = this;
        if (penaltyList.Count != 0 && index < penaltyList.Count) {
            hints.UpdatePromptText(penaltyList[index]);
        } else {
            hints.setText("There is no assistance left for this problem.");
        }
    }
    public void UpdateIndex(int index) {
        this.index = index;
        hints.indices[indexerNumber] = this.index;
        hints.UpdatePromptText(penaltyList[index]);
    }
    public void UpdateHintText() {
        hints.UpdatePromptText(penaltyList[index]);
    }
    public void UseHint() {
        if (penaltyList.Count != 0 && hintsList.Count != 0) {
            if (index < hintsList.Count) {
                usedHints++;
                hints.usedHints[indexerNumber] = this.usedHints;
                textObject.sentences[index] += hintsList[index];
                StartCoroutine(showText());
                gameTimer.AddPenalty(penaltyList[index]);
                index++;
                hints.indices[indexerNumber] = this.index;
                hints.textObjects[indexerNumber] = this.textObject;
            }
            if (index < hintsList.Count) {
                hints.UpdatePromptText(penaltyList[index]);
            } else {
                hints.setText("There is no assistance left for this problem.");
            }
        } else {
            hints.setText("There is no assistance left for this problem.");
        }
        hints.updateCameraScript();
    }
    IEnumerator showText() {
        yield return new WaitForSeconds(0.05f);
        TriggerText(textObject);
    }
    public void checkPreviousHints() {
        StartCoroutine(showText());
    }
}
