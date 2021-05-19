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

    public void puzzleReset()
    {
        puzzleComplete = false;
        for (int i = 0; i < bottomWires.Count; i++)
        {
            bottomWires[i].success = false;
            topWires[i].success = false;
            bottomWires[i].connected = false;
            topWires[i].connected = false;
            bottomWires[i].lineRenderer.SetPosition(0, Vector3.zero);
            bottomWires[i].lineRenderer.SetPosition(1, Vector3.zero);
        }
        currentHoveredWire = null;
        currentDraggedWire = null;
        nonHoveredWires.Clear();
        StopAllCoroutines();

    }
}