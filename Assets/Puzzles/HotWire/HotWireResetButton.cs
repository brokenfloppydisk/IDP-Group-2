using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotWireResetButton : MonoBehaviour
{
    public HotWirePuzzle puzzle;
    
    public void WireReset() {
        puzzle.puzzleComplete = false;
        for (int i = 0; i < puzzle.bottomWires.Count; i++) {
            puzzle.bottomWires[i].success = false;
            puzzle.topWires[i].success = false;
            puzzle.bottomWires[i].connected = false;
            puzzle.topWires[i].connected = false;
            puzzle.bottomWires[i].lineRenderer.SetPosition(0, Vector3.zero); 
            puzzle.bottomWires[i].lineRenderer.SetPosition(1, Vector3.zero); 
        }
        puzzle.currentHoveredWire = null;
        puzzle.currentDraggedWire = null;
        puzzle.nonHoveredWires.Clear();
        puzzle.StopAllCoroutines();
        puzzle.StartCoroutine(puzzle.CheckCompletion());

    }
}
