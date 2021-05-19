using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
    public LineRenderer lineRenderer;
    
    public bool isBeingDragged = false;
    private HotWirePuzzle puzzle;
    public int matchIndex;
    public bool success = false;
    public bool connected = false;
    [System.NonSerialized]
    public Canvas canvas;
    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        canvas = GetComponentInParent<Canvas>();
        puzzle = GetComponentInParent<HotWirePuzzle>();
    }
    void Update() {
        if (isBeingDragged) {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out movePos);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, canvas.transform.TransformPoint(movePos));
        } else { 
        if (!connected && puzzle.nonHoveredWires.Contains(this)) {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero); 
        } else {
            connected = true;
        }
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
        if (puzzle.topWires.Contains(this)) { return; }
        if (success) {return ;}
        isBeingDragged = true;
        puzzle.currentDraggedWire = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //unused
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (puzzle.currentHoveredWire != null) {
            if (puzzle.currentDraggedWire.matchIndex == puzzle.currentHoveredWire.matchIndex)  {
                if (puzzle.topWires.Contains(puzzle.currentHoveredWire)) {
                    success = true;
                    connected = true;
                    puzzle.currentHoveredWire.success = true;
                }
            }
        }
        isBeingDragged = false;
        puzzle.currentDraggedWire = null;
    }
}