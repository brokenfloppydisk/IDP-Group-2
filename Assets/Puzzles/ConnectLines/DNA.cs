using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DNA : HotWirePuzzle
{
    public List<Animator> animators;
    public void openLockMenu() {
        puzzleReset();
        setAnimationParam("PuzzleOpen", true);

    }
    public void closeLockMenu() {
        clearLineRenderers();
        setAnimationParam("PuzzleOpen", false);
    }
    public void openLock() {
        enterButton.interactable = false;
        resetButton.interactable = false;
        clearLineRenderers();
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
                openLock();
                puzzleComplete = true;
            }
        }
    }
    IEnumerator moveLineRenderers() {
        for (int i=0; i <= 1; i++) {
            List<Wire> possibleTopWires = topWires.ToList();
            if (i==0) {
                foreach (Wire wire in bottomWires) {
                    wire.lineRenderer.SetPosition(0,Vector3.zero);
                    wire.lineRenderer.SetPosition(1,Vector3.zero);
                }
                yield return new WaitForSeconds(0.45f);
            } else {
                foreach (Wire wire in bottomWires)
                {
                    wire.lineRenderer.SetPosition(0, wire.transform.position);
                    foreach (Wire otherWire in possibleTopWires)
                    {
                        if (otherWire.matchIndex == wire.matchIndex)
                        {
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
