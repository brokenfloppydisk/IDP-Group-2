using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ConnectPuzzle : MonoBehaviour {
    public Button resetButton;
    public Button enterButton;
    public List<Node> bottomNodes = new List<Node>();
    public List<Node> topNodes = new List<Node>();
    public bool puzzleComplete = false;
    [System.NonSerialized]
    public List<Node> nonHoveredWires = new List<Node>();
    [System.NonSerialized]
    public Node currentDraggedWire;
    [System.NonSerialized]
    public Node currentHoveredWire;
    public void puzzleReset()
    {
        for (int i = 0; i < bottomNodes.Count; i++)
        {
            bottomNodes[i].success = false;
            topNodes[i].success = false;
            bottomNodes[i].connected = false;
            topNodes[i].connected = false;
        }
        clearLineRenderers();
        currentHoveredWire = null;
        currentDraggedWire = null;
        nonHoveredWires.Clear();
    }
    public void clearLineRenderers() {
        for (int i = 0; i < bottomNodes.Count; i++) {
            bottomNodes[i].lineRenderer.SetPosition(0, Vector3.zero);
            bottomNodes[i].lineRenderer.SetPosition(1, Vector3.zero);
        }
    }
}