using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DNA : ConnectPuzzle
{
    public List<Animator> animators;
    public GameObject itemDescriptions;
    public void Start() {
        if (CameraScript.Instance.dnaLockOpened) {
            puzzleComplete = true;
            enterButton.interactable = false;
            resetButton.interactable = false;
            setAnimationParam("LockOpen", true);
            Hints hints = Hints.Instance;
            if (hints.sceneIndexer.index < 2) {
                hints.sceneIndexer.UpdateIndex(2);
                hints.sceneIndexer.UpdateHintText();
            }
        }
    }
    public void openLockMenu() {
        puzzleReset();
        itemDescriptions.gameObject.transform.position += new Vector3(0,-10000,0);
        setAnimationParam("PuzzleOpen", true);
    }
    public void closeLockMenu() {
        clearLineRenderers();
        itemDescriptions.gameObject.transform.position += new Vector3(0, 10000, 0);
        setAnimationParam("PuzzleOpen", false);
    }
    public void openLock() {
        Hints hints = Hints.Instance;
        if (hints.sceneIndexer.index < 2) {
            hints.sceneIndexer.UpdateIndex(2);
            hints.sceneIndexer.UpdateHintText();
        }
        enterButton.interactable = false;
        resetButton.interactable = false;
        clearLineRenderers();
        StartCoroutine(moveLineRenderers());
        setAnimationParam("LockOpen", true);
        setAnimationParam("PuzzleOpen", true);
        CameraScript.Instance.dnaLockOpened = true;
    }
    public void setAnimationParam(string param, bool value) {
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetBool(param, value);
        }
    }
    public void checkCompletion() {
        if (puzzleComplete != true){
            int successes = 0;
            for (int i = 0; i < topNodes.Count; i++) {
                if (topNodes[i].success) { successes++; }
            }
            if (successes >= topNodes.Count) {
                openLock();
                puzzleComplete = true;
            }
        }
    }
    IEnumerator moveLineRenderers() {
        for (int i=0; i <= 1; i++) {
            List<Node> possibleTopWires = topNodes.ToList();
            if (i==0) {
                foreach (Node wire in bottomNodes) {
                    wire.lineRenderer.SetPosition(0,Vector3.zero);
                    wire.lineRenderer.SetPosition(1,Vector3.zero);
                }
                yield return new WaitForSeconds(0.45f);
            } else {
                foreach (Node wire in bottomNodes) {
                    wire.lineRenderer.SetPosition(0, wire.transform.position);
                    foreach (Node otherWire in possibleTopWires) {
                        if (otherWire.matchIndex == wire.matchIndex) {
                            possibleTopWires.Remove(otherWire);
                            wire.lineRenderer.SetPosition(1, otherWire.transform.position);
                            break;
                        }
                    }
                }
            }
        }
    }
}
