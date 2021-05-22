using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Node : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    [System.NonSerialized]
    public LineRenderer lineRenderer;
    private ConnectPuzzle puzzle;
    public int matchIndex;
    public bool connected = false;
    [System.NonSerialized]
    public Canvas canvas;
    [System.NonSerialized]
    public bool isBeingDragged = false;
    public bool success = false;
    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        canvas = GetComponentInParent<Canvas>();
        puzzle = GetComponentInParent<ConnectPuzzle>();
    }
    void Update() {
        if (isBeingDragged) {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out movePos);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, canvas.transform.TransformPoint(movePos));
        } else { 
        }
        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, canvas.worldCamera);
        if (isHovered) {
            puzzle.currentHoveredWire = this;
            if (puzzle.nonHoveredWires.Contains(this)) {
                puzzle.nonHoveredWires.Remove(this);
            }
        } else {
            puzzle.nonHoveredWires.Add(this);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (puzzle.topNodes.Contains(this)) { return; }
        if (success) {return ;}
        isBeingDragged = true;
        puzzle.currentDraggedWire = this;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //unused but necessary
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!connected) {
            if (puzzle.topNodes.Contains(puzzle.currentHoveredWire) && puzzle.currentHoveredWire.connected != true){
                connected = true;
                puzzle.currentHoveredWire.connected = true;
                if (puzzle.currentDraggedWire.matchIndex == puzzle.currentHoveredWire.matchIndex) {
                    puzzle.currentHoveredWire.success = true;
                    success = true;
                }
                
            }
            
        }
        
        if (!connected) {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
        isBeingDragged = false;
        puzzle.currentDraggedWire = null;
    }
}