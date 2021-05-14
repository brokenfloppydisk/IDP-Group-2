using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class HotWirePuzzle : MonoBehaviour {
    public List<Wire> nonHoveredWires = new List<Wire>();
    public List<Wire> bottomWires = new List<Wire>();
    public List<Wire> topWires = new List<Wire>();
    public bool puzzleComplete = false;
    public Wire currentDraggedWire;
    public Wire currentHoveredWire;

    private void Awake() {
        StartCoroutine(CheckCompletion());
    }
    private void Update() {

    }

    public IEnumerator CheckCompletion() {
        while (!puzzleComplete) {
            int successes = 0;
            for (int i = 0; i < topWires.Count; i++) {
                if (topWires[i].success) { successes++; }
            }
            if (successes >= topWires.Count) {
                Debug.Log("Success"); //Need to implement in playerstats class
                puzzleComplete = true;
                this.StopCoroutine(CheckCompletion());
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

}