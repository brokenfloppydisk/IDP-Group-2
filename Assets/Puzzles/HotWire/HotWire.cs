using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotWire : HotWirePuzzle
{
    public void openPuzzle()
    {

    }
    public void closePuzzle()
    {

    }
    public void activateShip()
    {

    }

    public void checkCompletion()
    {
        if (puzzleComplete != true)
        {
            int successes = 0;
            for (int i = 0; i < topWires.Count; i++)
            {
                if (topWires[i].success) { successes++; }
            }
            if (successes >= topWires.Count)
            {
                Debug.Log("Success");
                activateShip();
                puzzleComplete = true;
            }
        }

    }
}
