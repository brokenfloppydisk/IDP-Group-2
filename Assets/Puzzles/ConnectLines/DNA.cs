using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : HotWirePuzzle
{
    public List<Animator> animators;
    public void openLockMenu() {
        setAnimationParam("PuzzleOpen", true);
    }
    public void closeLockMenu() {
        setAnimationParam("PuzzleOpen", false);
    }
    public void openLock() {
        StartCoroutine(moveLineRenderers());
        setAnimationParam("LockOpen", true);

    }
    public void setAnimationParam(string param, bool value) {
        for (int i = 0; i < animators.Count; i++) {
            animators[i].SetBool(param, value);
        }
    }
    public void checkCompletion() {
        if (puzzleComplete != true){
            int successes = 0;
            for (int i = 0; i < topWires.Count; i++) {
                if (topWires[i].success) { successes++; }
            }
            if (successes >= topWires.Count) {
                Debug.Log("Success");
                openLock();
                puzzleComplete = true;
            }
        }
    }
    IEnumerator moveLineRenderers() {
        for (int i=0; i <= 360; i++) {
            foreach (Wire wire in bottomWires) {
                wire.lineRenderer.SetPosition(0, transform.position);
                wire.lineRenderer.SetPosition(1, topWires[wire.matchIndex].transform.position);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
