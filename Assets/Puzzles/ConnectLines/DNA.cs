using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : HotWirePuzzle
{  
    
    public void openLockMenu() {

    }
    public void closeLockMenu() {

    }
    public void openLock() {

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
}
