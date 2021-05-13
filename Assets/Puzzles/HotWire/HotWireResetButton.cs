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
        }

    }
}
