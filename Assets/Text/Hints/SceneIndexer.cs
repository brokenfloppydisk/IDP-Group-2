using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneIndexer : TextTrigger
{
    private Hints hints = null;
    public int indexerNumber = -1;
    public int index = -1;
    private int usedHints = -1;
    [SerializeField]
    private TextObject textObject;
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
        hints = Hints.Instance;
        if (hints.alreadyInitializedText[indexerNumber]) {
            this.textObject = hints.textObjects[indexerNumber];
            this.usedHints = hints.usedHints[indexerNumber];
        } else {
            hints.textObjects[indexerNumber] = this.textObject;
            index = 0;
            hints.alreadyInitializedText[indexerNumber] = true;
        }
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
        UpdateHintText();
    }
    public void UpdateHintText() {
        if (index < penaltyList.Count) {
            hints.UpdatePromptText(penaltyList[index]);
        } else {
            hints.setText("There is no assistance left for this problem.");
        }
    }
    public void UseHint() {
        if (penaltyList.Count != 0 && hintsList.Count != 0) {
            if (index < hintsList.Count) {
                usedHints++;
                hints.usedHints[indexerNumber] = this.usedHints;
                textObject.sentences[index] += hintsList[index];
                StartCoroutine(showText());
                GameTimer.Instance.AddPenalty(penaltyList[index]);
                index++;
                hints.indices[indexerNumber] = this.index;
                hints.textObjects[indexerNumber] = this.textObject;
            }
            UpdateHintText();
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
