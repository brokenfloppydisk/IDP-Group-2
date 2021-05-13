using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class HotWirePuzzle : MonoBehaviour {
    public List<Wire> bottomWires = new List<Wire>();
    public List<Wire> topWires = new List<Wire>();

    public bool puzzleComplete = false;

    public Wire currentDraggedWire;
    public Wire currentHoveredWire;

    private void Awake() {
        StartCoroutine(CheckCompletion());
    }
    private IEnumerator CheckCompletion() {
        while (!puzzleComplete) {
            int successes = 0;
            for (int i = 0; i < topWires.Count; i++) {
                if (topWires[i].success) { successes++; }
            }
            if (successes >= topWires.Count) {
                Debug.Log("Success"); //Need to implement in another class
                puzzleComplete = false;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}